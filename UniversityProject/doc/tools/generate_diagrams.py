"""Generate editable draw.io diagrams and matching PNG previews for labs 5-8.
Requires Pillow. The lab 4 diagram supplies the unchanged model structure.
"""
from pathlib import Path
import xml.etree.ElementTree as E
import re, html, math, sys, heapq, collections
from PIL import Image, ImageDraw, ImageFont
BASE=Path(__file__).resolve().parents[1]/'ObjectOrientedPractics'
FONT='C:/Windows/Fonts/arial.ttf'

def node(root,name,x,y,lines,w=780):
    h=65+32*len(lines)
    c=E.SubElement(root,'mxCell',id=name,value='<b>'+html.escape(name)+'</b><hr>'+'<br>'.join(html.escape(v) for v in lines),style='rounded=0;whiteSpace=wrap;html=1;align=left;verticalAlign=top;spacing=10;fillColor=#e7eff7;',vertex='1',parent='1')
    E.SubElement(c,'mxGeometry',{'as':'geometry','x':str(x),'y':str(y),'width':str(w),'height':str(h)})
    return c

def edge(root,a,b,kind='uses',label='',**kw):
    style='edgeStyle=orthogonalEdgeStyle;endArrow=open;'
    if kind=='realization':style+='dashed=1;endArrow=block;endFill=0;'
    elif kind=='inheritance':style+='endArrow=block;endFill=0;'
    elif kind=='composition':style+='startArrow=diamond;startFill=1;'
    elif kind=='aggregation':style+='startArrow=diamond;startFill=0;'
    else:style+='dashed=1;'
    c=E.SubElement(root,'mxCell',id='newedge'+str(len(root)),value=label or kind,style=style,edge='1',parent='1',source=a,target=b)
    E.SubElement(c,'mxGeometry',{'as':'geometry','relative':'1'})

def append(root,name,lines):
    c=root.find(f"mxCell[@id='{name}']")
    c.set('value',c.get('value')+'<br>'+'<br>'.join(html.escape(v) for v in lines))
    g=c.find('mxGeometry');g.set('height',str(float(g.get('height'))+32*len(lines)))

def route_edges(diagram):
    """Route connectors through free space, keeping all class rectangles readable."""
    r = diagram.find('mxGraphModel/root')
    boxes = {}
    for c in r.findall("mxCell[@vertex='1']"):
        g = c.find('mxGeometry')
        boxes[c.get('id')] = tuple(float(g.get(k, '0')) for k in ['x', 'y', 'width', 'height'])
    step = 25
    W = int(max(x+w for x,y,w,h in boxes.values())/step)+12
    H = int(max(y+h for x,y,w,h in boxes.values())/step)+12
    blocked = set()
    for x,y,w,h in boxes.values():
        for gx in range(int(x/step)-1, int((x+w)/step)+2):
            for gy in range(int(y/step)-1, int((y+h)/step)+2): blocked.add((gx,gy))
    used = collections.Counter()
    edges = r.findall("mxCell[@edge='1']")
    endpoints = collections.defaultdict(list)
    faces = {}
    for c in edges:
        if c.get('source') not in boxes or c.get('target') not in boxes: continue
        for key,other in [('source','target'),('target','source')]:
            name = c.get(key); x,y,w,h = boxes[name]; a,b,cw,ch = boxes[c.get(other)]
            dx,dy = a+cw/2-(x+w/2),b+ch/2-(y+h/2)
            if abs(dx)/(w+100) > abs(dy)/(h+100): face = 'right' if dx>0 else 'left'
            else: face = 'bottom' if dy>0 else 'top'
            faces[(id(c),key)] = face
            endpoints[(name,face)].append((c,key))
    ports = {}
    for (name,face),entries in endpoints.items():
        x,y,w,h = boxes[name]
        for index,(c,key) in enumerate(entries):
            t = (index+1)/(len(entries)+1)
            if face in ['top','bottom']:
                px = round((x+max(30,min(w-30,w*t)))/step)*step
                py = y if face=='top' else y+h
                anchor = (int(px/step), int(y/step)-3 if face=='top' else int((y+h)/step)+3)
                port = (px,py)
            else:
                py = y+max(20,min(h-20,h*t)); px=x if face=='left' else x+w
                anchor = (int(x/step)-3 if face=='left' else int((x+w)/step)+3,round(py/step))
                port = (px,py)
            ports[(id(c),key)] = (port,anchor,face)
    for c in edges:
        if (id(c),'source') not in ports: continue
        p,start,face1 = ports[(id(c),'source')]; q,end,face2 = ports[(id(c),'target')]
        queue = [(0,0,start)]; prev = {}; distance = {start:0}
        while queue:
            _,cost,pos = heapq.heappop(queue)
            if cost!=distance.get(pos):continue
            if pos==end:break
            for dx,dy in [(1,0),(-1,0),(0,1),(0,-1)]:
                nxt=(pos[0]+dx,pos[1]+dy)
                if not (1<=nxt[0]<W and 1<=nxt[1]<H):continue
                if nxt in blocked and nxt not in [start,end]:continue
                value=cost+1+used[nxt]*4
                if value<distance.get(nxt,float('inf')):
                    distance[nxt]=value;prev[nxt]=pos
                    heapq.heappush(queue,(value+abs(nxt[0]-end[0])+abs(nxt[1]-end[1]),value,nxt))
        if end not in distance:continue
        path=[end]
        while path[-1]!=start:path.append(prev[path[-1]])
        path.reverse()
        for point in path:used[point]+=1
        points=[(a*step,b*step) for a,b in path]
        # Keep each segment orthogonal between the exact boundary port and grid.
        first=(points[0][0],p[1]) if face1 in ['left','right'] else (p[0],points[0][1])
        last=(points[-1][0],q[1]) if face2 in ['left','right'] else (q[0],points[-1][1])
        points=[p,first]+points+[last,q]
        simplified=[]
        for point in points:
            if simplified and point==simplified[-1]:continue
            if len(simplified)>1 and ((simplified[-2][0]==simplified[-1][0]==point[0]) or (simplified[-2][1]==simplified[-1][1]==point[1])):simplified.pop()
            simplified.append(point)
        st=c.get('style','')
        st=re.sub(r'(exitX|exitY|entryX|entryY)=[^;]*;','',st)
        a=boxes[c.get('source')];b=boxes[c.get('target')]
        st+=f'exitX={(p[0]-a[0])/a[2]};exitY={(p[1]-a[1])/a[3]};entryX={(q[0]-b[0])/b[2]};entryY={(q[1]-b[1])/b[3]};'
        c.set('style',st)
        geom=c.find('mxGeometry')
        for child in list(geom):geom.remove(child)
        arr=E.SubElement(geom,'Array',{'as':'points'})
        for px,py in simplified[1:-1]:E.SubElement(arr,'mxPoint',x=str(px),y=str(py))
        # Arrow shapes express relation types; repetitive labels obscure dense diagrams.
        if c.get('id','').startswith('newedge'):c.set('value','')

def render(diagram,path):
    r=diagram.find('mxGraphModel/root'); boxes={}
    for c in r.findall("mxCell[@vertex='1']"):
        g=c.find('mxGeometry');boxes[c.get('id')]=(c,tuple(float(g.get(k,'0')) for k in ['x','y','width','height']))
    W=int(max(v[1][0]+v[1][2] for v in boxes.values())+180);H=int(max(v[1][1]+v[1][3] for v in boxes.values())+180)
    im=Image.new('RGB',(W,H),'white');d=ImageDraw.Draw(im);font=ImageFont.truetype(FONT,25);bold=ImageFont.truetype('C:/Windows/Fonts/arialbd.ttf',29)
    def arrow(p,q,typ,fill):
        dx,dy=q[0]-p[0],q[1]-p[1];l=math.hypot(dx,dy)
        if not l:return
        ux,uy=dx/l,dy/l
        if typ=='diamond':pts=[q,(q[0]-15*ux+9*uy,q[1]-15*uy-9*ux),(q[0]-30*ux,q[1]-30*uy),(q[0]-15*ux-9*uy,q[1]-15*uy+9*ux)]
        else:pts=[q,(q[0]-24*ux+12*uy,q[1]-24*uy-12*ux),(q[0]-24*ux-12*uy,q[1]-24*uy+12*ux)]
        if typ=='open':d.line([pts[1],pts[0],pts[2]],fill='#31445b',width=2)
        else:d.polygon(pts,fill='#31445b' if fill else 'white',outline='#31445b',width=2)
    for c in r.findall("mxCell[@edge='1']"):
        if c.get('source') not in boxes or c.get('target') not in boxes:continue
        a=boxes[c.get('source')][1];b=boxes[c.get('target')][1];st=dict(x.split('=',1) for x in c.get('style','').split(';') if '=' in x)
        # Preserve explicit anchors and routing from the source draw.io file.
        if 'exitX' in st:
            p=(a[0]+float(st['exitX'])*a[2],a[1]+float(st['exitY'])*a[3]);q=(b[0]+float(st['entryX'])*b[2],b[1]+float(st['entryY'])*b[3])
        elif a[0]+a[2]<b[0]:p=(a[0]+a[2],a[1]+a[3]/2);q=(b[0],b[1]+b[3]/2)
        elif b[0]+b[2]<a[0]:p=(a[0],a[1]+a[3]/2);q=(b[0]+b[2],b[1]+b[3]/2)
        else:
            down=a[1]<b[1];p=(a[0]+a[2]/2,a[1]+(a[3] if down else 0));q=(b[0]+b[2]/2,b[1]+(0 if down else b[3]))
        pts=[p]+[(float(t.get('x')),float(t.get('y'))) for t in c.findall('.//mxPoint')]+[q]
        if len(pts)==2 and p[0]!=q[0] and p[1]!=q[1]:pts=[p,((p[0]+q[0])/2,p[1]),((p[0]+q[0])/2,q[1]),q]
        for start,end in zip(pts,pts[1:]):
            if st.get('dashed')=='1':
                length=math.dist(start,end)
                for k in range(0,int(length),18):
                    t=k/max(1,length);u=min(1,(k+10)/max(1,length));d.line((start[0]+(end[0]-start[0])*t,start[1]+(end[1]-start[1])*t,start[0]+(end[0]-start[0])*u,start[1]+(end[1]-start[1])*u),fill='#31445b',width=2)
            else:d.line((start,end),fill='#31445b',width=2)
        if st.get('endArrow') in ['block','open']:arrow(pts[-2],q,st['endArrow'],False)
        if st.get('startArrow')=='diamond':arrow(pts[1],p,'diamond',st.get('startFill')=='1')
        mid=pts[len(pts)//2];label=html.unescape(c.get('value',''));bb=d.textbbox((0,0),label,font=font);d.rectangle((mid[0]+4,mid[1]-32,mid[0]+bb[2]+12,mid[1]-3),fill='white');d.text((mid[0]+8,mid[1]-32),label,fill='#31445b',font=font)
    for name,(c,(x,y,w,h)) in boxes.items():
        d.rectangle((x,y,x+w,y+h),fill='#edf3fa',outline='#31445b',width=2)
        text=re.sub(r'<hr\s*/?>','\n',c.get('value',''));text=re.sub(r'<br\s*/?>','\n',text);text=html.unescape(re.sub('<[^>]*>','',text))
        if 'summary=1' in c.get('style',''):
            d.text((x+20,y+25),text,fill='#182c45',font=bold);continue
        lines=text.splitlines();d.text((x+12,y+10),lines[0],fill='#182c45',font=bold);d.line((x,y+51,x+w,y+51),fill='#31445b',width=2)
        for i,line in enumerate(lines[1:]):d.text((x+12,y+63+i*30),line,fill='#182c45',font=font)
    im.save(path)

def generate(n):
    tree=E.parse(BASE/'Practics4.drawio');model=tree.getroot().find('diagram');model.set('name','Model');r=model.find('mxGraphModel/root')
    # Services are omitted to leave room for the new discount architecture.
    for c in list(r):
        if c.get('id') in ['IdGenerator','ValueValidator'] or c.get('source') in ['IdGenerator','ValueValidator'] or c.get('target') in ['IdGenerator','ValueValidator']:r.remove(c)
    append(r,'Customer',['+ Discounts: List<IDiscount>'])
    append(r,'Order',['- _discountAmount: double','+ DiscountAmount: double','+ Total: double {get}'])
    node(r,'IDiscount',4400,500,['<<interface>>','+ Info: string {get}','+ Calculate(items: List<Item>): double','+ Apply(items: List<Item>): double','+ Update(items: List<Item>): void'])
    node(r,'PointsDiscount',4000,1250,['- Points: int {get; private set}','+ Info: string {get}','+ Calculate(items): double','+ Apply(items): double','+ Update(items): void']+(['+ CompareTo(other): int'] if n>=6 else []))
    node(r,'PercentDiscount',4900,1850,['- _purchases: double','+ Category: Category {get}','+ Percent: int {get}','+ Info: string {get}','+ Calculate(items): double','+ Apply(items): double','+ Update(items): void']+(['+ CompareTo(other): int'] if n>=6 else []))
    edge(r,'Customer','IDiscount','composition','1 : 1..*')
    edge(r,'PointsDiscount','IDiscount','realization','')
    edge(r,'PercentDiscount','IDiscount','realization','')
    if n>=6:
        for name,lines in [('Item',['+ Clone(): object','+ Equals(other: Item): bool','+ Equals(other: object): bool','+ GetHashCode(): int','+ CompareTo(other: Item): int']),('Address',['+ Clone(): object','+ Equals(other: Address): bool','+ Equals(other: object): bool','+ GetHashCode(): int']),('Cart',['+ Clone(): object']),('Order',['+ Equals(other: Order): bool','+ Equals(other: object): bool','+ GetHashCode(): int'])]:append(r,name,lines)
        # Standard interfaces deliberately shown, per the assignment.
        for i,(name,implementers) in enumerate([('ICloneable',['Item','Address','Cart']),('IEquatable<Item>',['Item']),('IEquatable<Address>',['Address']),('IEquatable<Order>',['Order']),('IComparable<Item>',['Item']),('IComparable<PointsDiscount>',['PointsDiscount']),('IComparable<PercentDiscount>',['PercentDiscount'])]):
            node(r,name,6000,i*330+80,['<<interface>>'],w=800)
            for cls in implementers:edge(r,cls,name,'realization')
    if n>=7:
        node(r,'DataTools',4400,2700,['<<static>>','+ Filter(items, criterion: Func<Item, bool>): List<Item>','+ CostAbove5000(item): bool','+ IsElectronics(item): bool','+ Sort(items, compare: Func<Item, Item, bool>): List<Item>','+ NameAscending(x, y): bool','+ CostAscending(x, y): bool','+ CostDescending(x, y): bool'],w=1050)
        edge(r,'DataTools','Item','uses')
    if n>=8:
        append(r,'Item',['<<events>> + NameChanged: EventHandler<EventArgs>','<<events>> + InfoChanged: EventHandler<EventArgs>','<<events>> + CostChanged: EventHandler<EventArgs>'])
        append(r,'Address',['<<events>> + AddressChanged: EventHandler<EventArgs>'])
    # Every stage has a separate view page with current state and methods.
    for old in list(tree.getroot().findall('diagram'))[1:]:tree.getroot().remove(old)
    v=E.SubElement(tree.getroot(),'diagram',name='Views');vr=E.SubElement(E.SubElement(v,'mxGraphModel',pageWidth='4500',pageHeight='3000'),'root');E.SubElement(vr,'mxCell',id='0');E.SubElement(vr,'mxCell',id='1',parent='0')
    views=[('MainForm',['- _store: Store']+(['- ItemsTab_ItemsChanged(sender, e): void','- RefreshDependentTabs(): void'] if n>=8 else ['- MainTabControl_SelectedIndexChanged(sender, e): void'])),('ItemsTab',['- _items: List<Item>','+ Items: List<Item>']+(['- _displayedItems: List<Item>','- SearchTextBox: TextBox','- SortComboBox: ComboBox','- RefreshItems(selected): void'] if n>=7 else [])+(['<<events>> + ItemsChanged: EventHandler<EventArgs>'] if n>=8 else [])),('CustomersTab',['+ Customers: List<Customer>','- DiscountsListBox: ListBox','- AddDiscountButton: Button','- RemoveDiscountButton: Button','- InitializeDiscounts(): void','- ShowDiscounts(): void']),('CartsTab',['+ Items: List<Item>','+ Customers: List<Customer>','- CurrentCustomer: Customer','- DiscountsCheckedListBox: CheckedListBox','- ShowDiscounts(reset): void','- UpdateDiscountTotals(index, state): void','+ RefreshData(): void']),('OrdersTab',['+ Customers: List<Customer>','+ Orders: List<Order>','- TotalLabel: Label','+ RefreshData(): void']),('PriorityOrdersTab',['+ Order: PriorityOrder','+ Items: List<Item>']),('AddressControl',['+ Address: Address','+ ReadOnly: bool','+ ValidateAddress(): bool']),('DiscountCategoryDialog',['+ SelectedCategory: Category {get}'])]
    for i,(name,lines) in enumerate(views):node(vr,name,100+(i%3)*1250,100+(i//3)*700,lines,w=1000)
    for cls in ['ItemsTab','CustomersTab','CartsTab','OrdersTab']:edge(vr,'MainForm',cls,'composition')
    for cls in ['CustomersTab','OrdersTab','PriorityOrdersTab']:edge(vr,cls,'AddressControl','composition')
    edge(vr,'CustomersTab','DiscountCategoryDialog','uses')
    if n>=8:
        append(vr, 'CustomersTab', ['<<events>> + CustomersChanged: EventHandler<EventArgs>', '+ RefreshData(): void', '- Customer_AddressChanged(sender, e): void'])
        append(vr, 'CartsTab', ['<<events>> + OrderCreated: EventHandler<EventArgs>'])
        append(vr, 'ItemsTab', ['- _observedItems: HashSet<Item>', '- Item_Changed(sender, e): void', '- SubscribeItem(item): void', '- UnsubscribeItem(item): void', '- UnsubscribeItems(): void'])
        append(vr, 'AddressControl', ['- _editingAddress: bool', '- Address_AddressChanged(sender, e): void'])
        append(vr, 'MainForm', ['- CustomersTab_CustomersChanged(sender, e): void', '- CartsTab_OrderCreated(sender, e): void'])
        # A separate reduced diagram shows every production class, without members.
        summary = E.SubElement(tree.getroot(), 'diagram', name='Overview')
        sr = E.SubElement(E.SubElement(summary, 'mxGraphModel', pageWidth='6000', pageHeight='5000'), 'root')
        E.SubElement(sr, 'mxCell', id='0'); E.SubElement(sr, 'mxCell', id='1', parent='0')
        names = ['Program', 'MainForm', 'Store', 'ItemsTab', 'CustomersTab', 'CartsTab', 'OrdersTab', 'PriorityOrdersTab', 'DiscountCategoryDialog', 'AddressControl', 'Customer', 'Cart', 'Order', 'PriorityOrder', 'Address', 'Item', 'IDiscount', 'PointsDiscount', 'PercentDiscount', 'Category', 'OrderStatus', 'DataTools', 'IdGenerator', 'ValueValidator', 'InputValidation']
        for i, name in enumerate(names):
            cell=node(sr, name, 100+(i%5)*1100, 100+(i//5)*650, [], w=850)
            cell.set('value',html.escape(name));cell.set('style',cell.get('style')+'summary=1;')
            cell.find('mxGeometry').set('height','120')
        relations = [
            ('Program','MainForm','uses'), ('MainForm','Store','composition'),
            ('MainForm','ItemsTab','composition'), ('MainForm','CustomersTab','composition'),
            ('MainForm','CartsTab','composition'), ('MainForm','OrdersTab','composition'),
            ('Store','Customer','composition'), ('Store','Item','composition'),
            ('Customer','Cart','composition'), ('Customer','Order','composition'),
            ('Customer','Address','composition'), ('Customer','IDiscount','composition'),
            ('Cart','Item','aggregation'), ('Order','Item','aggregation'), ('Order','Address','composition'),
            ('PriorityOrder','Order','inheritance'), ('PointsDiscount','IDiscount','realization'),
            ('PercentDiscount','IDiscount','realization'), ('Item','Category','uses'), ('Order','OrderStatus','uses'),
            ('PercentDiscount','Category','uses'), ('ItemsTab','DataTools','uses'), ('ItemsTab','Item','uses'),
            ('CustomersTab','Customer','uses'), ('CustomersTab','DiscountCategoryDialog','uses'),
            ('CustomersTab','PointsDiscount','uses'), ('CustomersTab','PercentDiscount','uses'),
            ('CartsTab','Customer','uses'), ('CartsTab','IDiscount','uses'), ('CartsTab','Order','uses'),
            ('CartsTab','PriorityOrder','uses'), ('OrdersTab','Order','uses'), ('OrdersTab','PriorityOrder','uses'),
            ('PriorityOrdersTab','PriorityOrder','uses'), ('PriorityOrdersTab','Item','uses'),
            ('CustomersTab','AddressControl','composition'), ('OrdersTab','AddressControl','composition'),
            ('PriorityOrdersTab','AddressControl','composition'), ('AddressControl','Address','uses'),
            ('Item','IdGenerator','uses'), ('Customer','IdGenerator','uses'), ('Order','IdGenerator','uses'),
            ('Item','ValueValidator','uses'), ('Customer','ValueValidator','uses'), ('Address','ValueValidator','uses'),
            ('ItemsTab','InputValidation','uses'), ('CustomersTab','InputValidation','uses'), ('AddressControl','InputValidation','uses'),
            ('DataTools','Item','uses')]
        for a,b,kind in relations: edge(sr,a,b,kind)

    # Make compartments fit every member, including the new interface methods.
    for diagram in tree.getroot().findall('diagram'):
        for cell in diagram.findall(".//mxCell[@vertex='1']"):
            geom = cell.find('mxGeometry')
            count = len(re.split(r'<br>|<hr>', cell.get('value', '')))
            geom.set('height', str(max(float(geom.get('height')), 85 + 30 * (count - 1))))
            text=re.sub(r'<hr\s*/?>','\n',cell.get('value',''))
            text=re.sub(r'<br\s*/?>','\n',text)
            lines=html.unescape(re.sub('<[^>]*>','',text)).splitlines()
            regular=ImageFont.truetype(FONT,25)
            heading=ImageFont.truetype('C:/Windows/Fonts/arialbd.ttf',29)
            width=max([heading.getlength(lines[0])]+[regular.getlength(line) for line in lines[1:]])+30
            geom.set('width',str(max(float(geom.get('width')),math.ceil(width))))
    r.find("mxCell[@id='Category']/mxGeometry").set('y', '3000')
    r.find("mxCell[@id='OrderStatus']/mxGeometry").set('y', '2350')
    for diagram in tree.getroot().findall('diagram'): route_edges(diagram)
    tree.write(BASE/f'Practics{n}.drawio' ,encoding='utf-8',xml_declaration=True)
    render(model,BASE/f'Practics{n}.png');render(v,BASE/f'Practics{n}-Views.png')
    if n>=8: render(summary,BASE/f'Practics{n}-Overview.png')
if __name__=='__main__':generate(int(sys.argv[1]))
