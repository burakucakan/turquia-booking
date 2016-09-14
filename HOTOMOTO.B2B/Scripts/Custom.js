/* SOL TARAFI GİZLEYİP FULL MODA GEÇME / AÇIP NORMAL MODA GEÇME*/
function SideVisible(Side, Visible) {
    $get(Side + 'Cell').style.display=Visible;
    $get(Side + 'Space').style.display=Visible;
}

/* DIV TOOLTIP MOUSE YAKINLARINDA GÖSTER */
function ShowToolTip(Cuurent, ToolTipID, Message)
{   
       document.getElementById(ToolTipID).innerHTML=Message;

       document.getElementById(ToolTipID).style.Left=Cuurent.offsetLeft + 8;
       document.getElementById(ToolTipID).style.Top=Cuurent.offsetTop + 10;
       
       /*document.getElementById(ToolTipID).visibility = 'visible';*/
       document.getElementById(ToolTipID).style.display = 'block';
}

/* DIV TOOLTIP GİZLE */
function HideToolTip(ToolTipID){
     document.getElementById(ToolTipID).style.display = 'none';
}

function HotelDetail(HotelID) {
    var WPen = window.open('HotelDetail.aspx?HotelID=' + HotelID, 'TurquiaHotelDetail', 'toolbar=no,width=770,height=440,scrollbars,resizable');
    WPen.focus();
    return;
}

function TourDetail(TourID, TourType) {
    var WPen = window.open('TourDetail.aspx?TourID=' + TourID + '&TourType=' + TourType, 'TurquiaTourDetail', 'toolbar=no,width=750,height=470,scrollbars,resizable');
    WPen.focus();
    return;
}

function RoomsDetail() {
    var WPen = window.open('RoomDetail.aspx', 'TurquiaRoomDetail', 'toolbar=no,width=750,height=550,scrollbars,resizable');
    WPen.focus();
    return;
}

function Zoom(FileName) {
    var WPen = window.open('Zoom.aspx?Image=' + FileName, 'TurquiaImages', 'toolbar=no,status');
    WPen.focus();
    return;
}

function OpenPrivacy() {
    var WPen = window.open('Privacy.aspx', 'TurquiaImages', 'width=350, height=470, toolbar=no, status');
    WPen.focus();
    return;
}