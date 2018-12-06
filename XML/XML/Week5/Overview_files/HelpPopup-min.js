
function PopupWindowAnchor(anchorObject)
{anchorObject.target="popup;";return PopupWindowLink(anchorObject);}
function PopupWindowAnchorCustomSize(anchorObject,popW,popH)
{anchorObject.target="popup;";return PopupWindowLink(anchorObject,popW,popH);}
function PopupWindowAnchorCustomSizePct(anchorObject,popWPct,popHPct)
{anchorObject.target="popup;";return PopupWindowLink(anchorObject,0,0,popWPct,popHPct);}
function PopupWindowLink(link,width,height,widthPrcnt,heightPrcnt)
{var w=screen.width;var h=screen.height;var popW;var popH;if(width==undefined)
{popW=450;}
else if(widthPrcnt!=undefined)
{popW=w*widthPrcnt;}
else
{popW=width;}
if(height==undefined)
{popH=375;}
else if(heightPrcnt!=undefined)
{popH=h*heightPrcnt;}
else
{popH=height;}
var leftPos=(w/2)-(popW/2);var topPos=(h/2)-(popH/2);var w=window.open(link,'popup','width='+popW+',height='+popH+',top='+topPos+',left='+leftPos+',scrollbars=1,resizable=1');w.focus();return false;}