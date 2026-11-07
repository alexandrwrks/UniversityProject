"""Generate editable draw.io diagrams and matching PNG previews for labs 5-8.
Requires Pillow. The lab 4 diagram supplies the unchanged model structure.
"""
from pathlib import Path
import xml.etree.ElementTree as E
import re, html, math, sys
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
    else:style+='dashed=1;'
    c=E.SubElement(root,'mxCell',id='newedge'+str(len(root)),value=label or kind,style=style,edge='1',parent='1',source=a,target=b)
    E.SubElement(c,'mxGeometry',{'as':'geometry','relative':'1'})

def append(root,name,lines):
    c=root.find(f"mxCell[@id='{name}']")
    c.set('value',c.get('value')+'<br>'+'<br>'.join(html.escape(v) for v in lines))
    g=c.find('mxGeometry');g.set('height',str(float(g.get('height'))+32*len(lines)))

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
        d.polygon(pts,fill='#31445b' if fill else 'white',outline='#31445b',width=2)
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
    # Make compartments fit every member, including the new interface methods.
    for diagram in tree.getroot().findall('diagram'):
        for cell in diagram.findall(".//mxCell[@vertex='1']"):
            geom = cell.find('mxGeometry')
            count = len(re.split(r'<br>|<hr>', cell.get('value', '')))
            geom.set('height', str(max(float(geom.get('height')), 85 + 30 * (count - 1))))
    r.find("mxCell[@id='Category']/mxGeometry").set('y', '3000')
    r.find("mxCell[@id='OrderStatus']/mxGeometry").set('y', '2350')
    tree.write(BASE/f'Practics{n}.drawio' ,encoding='utf-8',xml_declaration=True)
    render(model,BASE/f'Practics{n}.png');render(v,BASE/f'Practics{n}-Views.png')
if __name__=='__main__':generate(int(sys.argv[1]))
