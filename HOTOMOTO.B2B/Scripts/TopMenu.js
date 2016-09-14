function TopMenuOver(CommandID, Event) {
    if (Event == 1) {
        $get('TabTop' + CommandID).className='TabTopOver';
    } else if (Event == 0) { 
        $get('TabTop' + CommandID).className='TabTop';
    }
}