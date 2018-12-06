
if(document.all)
window.attachEvent("onload",begin);else
window.addEventListener("load",begin,true);var blnLocalizationWait=false;function begin()
{if(document.documentElement.innerHTML.indexOf("LOCALIZATIONSPANSTARTTEXT")<0){return;}
createVariables();doProcessLocalizationTokens();}
function doProcessLocalizationTokens()
{if(blnLocalizationWait){window.setTimeout("doProcessLocalizationTokens()",25);return;}
else{if(document.body.innerHTML.indexOf('<FRAME')==-1)
{if(top.ConstantsCreated!=2)
{window.setTimeout("doProcessLocalizationTokens()",25);return;}
processDocument(document.documentElement);done=true;if(shouldIBeHiddenItemsPlace()){window.setTimeout("createHiddenItemsTable()",25);}
else
{spanStuff();}}}}
function processValidators()
{if(typeof(Page_Validators)!="undefined"){for(var i=0;i<Page_Validators.length;i++){Page_Validators[i].title=clearLocalizationPhrases(Page_Validators[i].title);Page_Validators[i].errormessage=clearLocalizationPhrases(Page_Validators[i].errormessage);}}}
function processDocument(parent)
{for(var i=0;i<parent.childNodes.length;i++)
{processDocument(parent.childNodes[i]);}
switch(parent.tagName)
{case"SCRIPT":var content=processHiddenElement(parent.text,"Javascript contents");if(content!=parent.text&&content!=null)
parent.text=content;break;case"INPUT":parent.value=processElement(parent.value,parent);parent.alt=processElement(parent.alt,parent);break;case"TEXTAREA":parent.value=processHiddenElement(parent.defaultValue,"Default Text for "+parent.name);break;case"FORM":for(var i=0;i<parent.attributes.length;i++){var objAttr=parent.attributes[i];if(objAttr.value!=null&&objAttr.value!="null"&&objAttr.value.length>0){var strNewAttr=processHiddenElement(objAttr.value,"Javascript for "+parent.nodeName+'.'+objAttr.name);if(strNewAttr!=objAttr.value){parent.attributes[i].value=strNewAttr;}}}
break;case"IMG":if(parent.src.indexOf('c1chartimage.aspx')<0)
{parent.alt=processElement(parent.alt,parent);parent.src=processElement(unescape(parent.src),null);parent.title=processElement(parent.title,parent);parent.src=processElement(unescape(parent.src),null);}
break;case"A":parent.title=processHiddenElement(parent.title,"Link Title");if(parent.href!='undefined'&&parent.href.length>0)
{var strUnescHRef=unescape(parent.href);var strNewHRef=processHiddenElement(strUnescHRef,"Link URL");if(strNewHRef!=strUnescHRef)
parent.href=strNewHRef;}
var content=parent.attributes.getNamedItem("onclick");if(content!=null&&content.value!="null"&&getLocalSpan(content.value)!=null)
{content.value=processHiddenElement(content.value,"Link Onclick");}
updateParentInnerHTML(parent);break;case"SELECT":for(var j=0;j<parent.options.length;j++)
{if(parent.options[j].value.indexOf(top.STARTNAMESPACE)==0)
{parent.options[j].text+=parent.options[j].value.substring(0,parent.options[j].value.lastIndexOf(":"));parent.options[j].value=parent.options[j].value.substring(parent.options[j].value.lastIndexOf(":")+1);}
parent.options[j].text=processElement(parent.options[j].text,parent);parent.options[j].value=processElement(parent.options[j].value,null);}
break;case"TITLE":break;case"IFRAME":parent.src=processHiddenElement(parent.src,"Iframe Src for"+parent.id);break;case"DIV":parent.title=processHiddenElement(parent.title,"Div Title");updateParentInnerHTML(parent);break;case"MAP":parent.title=processHiddenElement(parent.title,"Map Title");updateParentInnerHTML(parent);break;case"SPAN":case"TD":case"B":updateParentInnerHTML(parent);break;case"H2":if(parent.id.toLowerCase().indexOf('tab')>=0&&parent.innerHTML.indexOf(top.TOKENCLASS)>=0){parent.innerHTML=unEscape(parent.innerHTML.replace('href="#"',''));parent.innerHTML=unEscape(parent.innerHTML.replace('title=""',''));}
break;}
processValidators();}
function updateParentInnerHTML(parent)
{var strNewInner=unEscape(parent.innerHTML);strNewInner=strNewInner.replace('href="#"','');strNewInner=strNewInner.replace('title="#"','');while(strNewInner.indexOf("href=\""+window.location.href+"#\"")>=0){strNewInner=strNewInner.replace("href=\""+window.location.href+"#\"","");}
if(parent.innerHTML!=strNewInner)
{parent.innerHTML=strNewInner;}}
function updateParentOuterHTML(parent)
{var strNewOuter=unEscape(parent.outerHTML);strNewOuter=strNewOuter.replace('href="#"','');strNewOuter=strNewOuter.replace('title="#"','');while(strNewOuter.indexOf("href=\""+window.location.href+"#\"")>=0){strNewOuter=strNewOuter.replace("href=\""+window.location.href+"#\"","");}
if(parent.outerHTML!=strNewOuter)
{parent.outerHTML=strNewOuter;}}
function spanStuff()
{if(document.styleSheets.length==0&&document.body.innerHTML.indexOf('<frameset>')==-1){document.body.innerHTML+="<style type=\"text/css\">"+top.localStyle+"<\/style>";}
else if(document.body.innerHTML.indexOf('<frameset>')==-1){document.body.innerHTML+="<style type=\"text/css\">"+top.localStyle+"<\/style>";}
createTokens(document.documentElement);if(top.translationWindow!=null&&!top.translationWindow.closed&&top.translationWindow.add)
{self.addMe=false;self.transTokIndex=top.translationWindow.add(self.tokens);}
else
{self.addMe=true;}
if(document.all){window.attachEvent("onunload",onUnload);}
else{window.addEventListener("unload",onUnload,true);}}
function createTokens(parent)
{var text="";var link=null;var token=null;for(var i=0;i<parent.childNodes.length;i++)
createTokens(parent.childNodes[i]);if(parent.tagName==top.LOCALTAG&&parent.className==top.LOCALCLASS)
{for(var x=0;x<parent.childNodes.length;x++)
{if(parent.childNodes[x].className==top.LINKCLASS)
{link=parent.childNodes[x];}
else if(parent.childNodes[x].className==top.TEXTCLASS)
{if(document.all)
parent.childNodes[x].clearAttributes();else
parent.childNodes[x].removeAttribute("class");}
else if(parent.childNodes[x].className==top.TOKENCLASS)
{token=parent.childNodes[x];}}
if(token!=null&&link!=null)
{if(document.all)
{link.token=token.innerText;link.attachEvent("onmouseout",cancelAssign);link.attachEvent("onmouseover",assignToken);}
else
{link.token=token.textContent;link.addEventListener("mouseout",cancelAssign,true);link.addEventListener("mouseover",assignToken,true);}
self.tokens.push(link);}
if(document.all)
parent.clearAttributes();else
parent.removeAttribute("class");}}
function createHiddenItemsTable()
{if(!areAllDone(top))
{window.setTimeout("createHiddenItemsTable()",1000);return;}
var contents=recAddItems(top);if(document.body.innerHTML.indexOf('<frameset>')==-1&&contents!="")
{var tbody=document.createElement("TBODY");var trs=contents.split('<--TR-->');for(r=0;r<trs.length;r++)
{var tr=document.createElement("TR");var tds=trs[r].split('<--TD-->');for(d=0;d<tds.length;d++)
{var td=document.createElement("TD");td.innerHTML=tds[d];tr.appendChild(td);}
tbody.appendChild(tr);}
var tab=document.createElement("TABLE");tab.border=1;tab.cellPadding=5;tab.appendChild(tbody);document.body.insertBefore(tab);}
spanStuff();if(getCookie("transWindow")=="true"&&top.translationWindow==null)
top.translationWindow=window.open(getCookie("transWindowP"),null,'height=80,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,left='+getCookie("transWindowX")+',top='+getCookie("transWindowY"));}
function recAddItems(place,el)
{var temp="";if(place.hiddenElements!=null){for(var y=0;y<place.hiddenElements.length;y++){temp+=place.hiddenElements[y];}}
for(var x=0;x<place.frames.length;x++){temp+=recAddItems(place.frames[x]);}
return temp;}
function areAllDone(place){for(var x=0;x<place.frames.length;x++){if(place.frames[x].done!=null&&!place.frames[x].done)
{if(place.frames[x].document.body.innerHTML.indexOf('<FRAME')==-1)
{return false;}}
if(place.frames[x].length>0){if(!areAllDone(place.frames[x])){return false;}}}
return true;}
function shouldIBeHiddenItemsPlace(){if(self.frames.length>0)
for(var i=0;i<self.frames.length;i++)
if(self.frames[i].doProcessLocalizationTokens)
return false;var parent=self;while(parent!=parent.parent){if(parent.parent.frames[parent.parent.frames.length-1]!=parent)
return false;parent=parent.parent;}
return true;}
function getLocalSpan(text)
{if(text==null)
return null;var start=text.indexOf(top.STARTTEXT);if(start<0)
return null;var end=text.indexOf(top.ENDSPAN,start);if(end<0)
return null;end+=top.ENDSPAN.length;start=text.substring(start,end).lastIndexOf(top.STARTTEXT)+start;return text.substring(start,end);}
function getText(localSpan)
{var start=localSpan.indexOf(top.STARTTEXT);if(start<0)
return"";start+=top.STARTTEXT.length;var end=localSpan.indexOf(top.STARTNAMESPACE,start)
if(end<0)
return"";return localSpan.substring(start,end);}
function getNamespace(localSpan)
{var start=localSpan.indexOf(top.STARTNAMESPACE);if(start<0)
return"";start+=top.STARTNAMESPACE.length;var end=localSpan.indexOf(top.STARTTOKEN,start)
if(end<0)
return"";return localSpan.substring(start,end);}
function getToken(localSpan)
{var start=localSpan.indexOf(top.STARTTOKEN);if(start<0)
return"";start+=top.STARTTOKEN.length;var end=localSpan.indexOf(top.ENDSPAN,start)
if(end<0)
return"";return localSpan.substring(start,end);}
function processHiddenElement(contents,title)
{if(contents==null)
return null;if(contents.length==0)
return'';while((temp=getLocalSpan(contents))!=null)
{contents=contents.replace(new RegExp(regExEscape(temp),top.giString),getText(temp));hiddenElements.push(title+"<--TD-->"+unEscape(temp)+"<--TR-->");}
return contents;}
function replaceLocalizationSpans(contents)
{if(contents==null)
return null;if(contents.length==0)
return'';while((temp=getLocalSpan(contents))!=null)
{contents=contents.replace(new RegExp(regExEscape(temp),top.giString),getText(temp));}
return contents;}
function processElement(contents,place)
{if(contents==null)
return null;while((temp=getLocalSpan(contents))!=null)
{contents=contents.replace(new RegExp(regExEscape(temp),top.giString),getText(temp));if(place!=null)
place.parentNode.insertBefore(createLocalizationSpan(getNamespace(temp),getToken(temp),null),place.nextSibling);}
return contents;}
function createLocalizationSpan(Namespace,Token,Text)
{var el=document.createElement(top.LOCALTAG);el.className=top.LOCALCLASS;if(Text!=null)
el.appendChild(createTextNode(Text));el.appendChild(createNamespaceNode(Namespace));el.appendChild(createTokenNode(Token));return el;}
function createTextNode(Text)
{var el=document.createElement(top.LOCALTAG);el.className=top.TEXTCLASS;el.innerHTML=Text;return el;}
function createNamespaceNode(Namespace)
{var el=document.createElement(top.LOCALTAG);el.className=top.LINKCLASS;el.NAMESPACE=Namespace;el.innerHTML=top.LINKCONTENTS;return el;}
function createTokenNode(Token)
{var el=document.createElement(top.LOCALTAG);el.className=top.TOKENCLASS;el.innerHTML=Token;return el;}
function unEscape(temp){if(temp==null)
return null;temp=temp.replace(top.regSTARTTEXT,top.STARTTEXTHTML);temp=temp.replace(top.regSTARTNAMESPACE,top.STARTNAMESPACEHTML);temp=temp.replace(top.regSTARTTOKEN,top.STARTTOKENHTML);temp=temp.replace(top.regENDSPAN,top.ENDSPANHTML);return temp;}
function clearLocalizationPhrases(temp){if(temp==null)
return null;temp=temp.replace(top.regSTARTTEXT,"");temp=temp.replace(top.regALL,"");return temp;}
function regExEscape(text)
{text=text.replace(top.regExpEscapeExp[0],"\\\\");text=text.replace(top.regExpEscapeExp[1],"\\(");text=text.replace(top.regExpEscapeExp[2],"\\)");text=text.replace(top.regExpEscapeExp[3],"\\.");text=text.replace(top.regExpEscapeExp[4],"\\[");text=text.replace(top.regExpEscapeExp[5],"\\]");text=text.replace(top.regExpEscapeExp[6],"\\*");text=text.replace(top.regExpEscapeExp[7],"\\?");text=text.replace(top.regExpEscapeExp[8],"\\+");text=text.replace(top.regExpEscapeExp[9],"\\{");text=text.replace(top.regExpEscapeExp[10],"\\}");text=text.replace(top.regExpEscapeExp[11],"\\^");text=text.replace(top.regExpEscapeExp[12],"\\$");return text;}
function onUnload()
{if(top.translationWindow!=null&&!top.translationWindow.closed)
{if(self.transTokIndex>=0&&top.translationWindow.removeTokensAt){if(top.translationWindow.currentTokenIndex1==self.transTokIndex)
top.translationWindow.deselectCurrentToken();top.translationWindow.removeTokensAt(self.transTokIndex);}
if(top.translationWindow.empty&&top.translationWindow.empty())
{top.translationWindow.fclose=true;top.translationWindow.close();top.translationWindow=null;}}}
function assignToken()
{if(window.event!=null&&window.event.srcElement!=null)
{if(window.event.srcElement!=top.tokenToSelect)
cancelAssign();else
return;top.assigned=true;top.tokenToSelect=window.event.srcElement;top.currentHover=window.setTimeout("selectToken()",1000);}}
function delayReload()
{for(var i=0;i<top.frames.length;i++)
top.frames[i].location.reload(true);}
function cancelAssign()
{if(top.currentHover>=0)
{clearTimeout(top.currentHover);top.currentHover=-1;top.tokenToSelect=null;}}
function selectToken()
{if(top.tokenToSelect==null||top.translationWindow==null||top.translationWindow.closed)
return;if(top.translationWindow.selectTokenHover)
top.translationWindow.selectTokenHover(top.tokenToSelect);}
function getCookie(name)
{var dc=document.cookie;var prefix=name+"=";var begin=dc.indexOf("; "+prefix);if(begin==-1)
{begin=dc.indexOf(prefix);if(begin!=0)
return null;}
else
{begin+=2;}
var end=document.cookie.indexOf(";",begin);if(end==-1)
end=dc.length;return unescape(dc.substring(begin+prefix.length,end));}
function closeTranslator(path)
{try
{if(!top.translationWindow){openTranslator(gstrTranslationWindowURL);}else{top.translationWindow.close();}}
catch(e){}}
function openTranslator(path)
{top.translationWindow=window.open(path,null,'height=120px,width=765px,status=no,toolbar=no,menubar=no,location=no,scrollbars=no');}
function createVariables()
{self.hiddenElements=new Array();self.done=false;self.addMe=false;self.tokens=new Array();self.transTokIndex=-1;if(top.translationWindow==null)
if(window.opener!=null&&!window.opener.closed)
top.translationWindow=window.opener.top.translationWindow;else
top.translationWindow=null;var amCreating=false;if(top.ConstantsCreated!=1&&top.ConstantsCreated!=2){top.ConstantsCreated=1;amCreating=true;top.assigned=false;top.currentHover=-1;top.tokenToSelect=null;top.LOCALTAG="SPAN";top.LOCALCLASS="LOCALIZATIONSPAN";top.TEXTCLASS="RESOURCETOKENTEXT";top.LINKCLASS="RESOURCETOKENLINK";top.TOKENCLASS="RESOURCETOKENHIDDEN";var linkContentString="&nbsp;]";var localStyleString=top.LOCALTAG+"."+top.LINKCLASS+" { font-family: Webdings; cursor: pointer; color: lightgrey;} "
+top.LOCALTAG+"."+top.TOKENCLASS+" { display: none; } "
+top.LOCALTAG+"."+top.TEXTCLASS+" { display: none; } ";if(navigator&&!(navigator.appName=="Microsoft Internet Explorer")){linkContentString="&nbsp;&#x2601;"
localStyleString=top.LOCALTAG+"."+top.LINKCLASS+" { cursor: pointer; color: lightgrey;} "
+top.LOCALTAG+"."+top.TOKENCLASS+" { display: none; } "
+top.LOCALTAG+"."+top.TEXTCLASS+" { display: none; } ";}
top.LINKCONTENTS=linkContentString;top.STARTTEXT="LOCALIZATIONSPANSTARTTEXT";top.STARTNAMESPACE="ENDTEXTLOCALIZATIONSPANSTARTNAMESPACE";top.STARTTOKEN="ENDNAMESPACELOCALIZATIONSPANSTARTTOKEN";top.ENDSPAN="ENDTOKENLOCALIZATIONSPAN";top.STARTTEXTHTML="<"+top.LOCALTAG+" CLASS="+top.LOCALCLASS+"><"+top.LOCALTAG+" CLASS="+top.TEXTCLASS+">";top.STARTNAMESPACEHTML="<\/"+top.LOCALTAG+"><"+top.LOCALTAG+" CLASS="+top.LINKCLASS+" NAMESPACE=";top.STARTTOKENHTML=">"+top.LINKCONTENTS+"<\/"+top.LOCALTAG+"><"+top.LOCALTAG+" CLASS="+top.TOKENCLASS+">";top.ENDSPANHTML="<\/"+top.LOCALTAG+"><\/"+top.LOCALTAG+">";top.giString="gi";top.localStyle=localStyleString;}
if(amCreating||(top.ConstantsCreated==2&&!(top.regSTARTTEXT instanceof RegExp))){top.regSTARTTEXT=new RegExp(top.STARTTEXT,top.giString);top.regSTARTNAMESPACE=new RegExp(top.STARTNAMESPACE,top.giString);top.regSTARTTOKEN=new RegExp(top.STARTTOKEN,top.giString);top.regENDSPAN=new RegExp(top.ENDSPAN,top.giString);top.regALL=new RegExp(top.STARTNAMESPACE+".*"+top.STARTTOKEN+".*"+top.ENDSPAN,top.giString);top.regExpEscapeExp=new Array();top.regExpEscapeExp[0]=new RegExp("\\\\",top.giString);top.regExpEscapeExp[1]=new RegExp("\\\(",top.giString);top.regExpEscapeExp[2]=new RegExp("\\\)",top.giString);top.regExpEscapeExp[3]=new RegExp("\\\.",top.giString);top.regExpEscapeExp[4]=new RegExp("\\\[",top.giString);top.regExpEscapeExp[5]=new RegExp("\\\]",top.giString);top.regExpEscapeExp[6]=new RegExp("\\\*",top.giString);top.regExpEscapeExp[7]=new RegExp("\\\?",top.giString);top.regExpEscapeExp[8]=new RegExp("\\\+",top.giString);top.regExpEscapeExp[9]=new RegExp("\\\{",top.giString);top.regExpEscapeExp[10]=new RegExp("\\\}",top.giString);top.regExpEscapeExp[11]=new RegExp("\\\^",top.giString);top.regExpEscapeExp[12]=new RegExp("\\\$",top.giString);top.ConstantsCreated=2;}}