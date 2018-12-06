
var redir_url='';var redir_delay='';var redir_target='';var action_messages=new Array();function SetRedirUrl(url){if(url&&url.length>0)
{redir_url=url;}}
function SetRedirDelay(delay){if(delay&&delay.length>0)
{redir_delay=delay;}}
function SetRedirTarget(target){if(target&&target.length>0)
{redir_target=target;}}
function writeActionMessages(){var messageDiv=document.getElementById("ActionMessages");if(messageDiv){for(var i=0;i<action_messages.length;i++){SetRedirDelay(-1);var newDiv=document.createElement("div");var newSpan=document.createElement("span");newDiv.className="normalDiv";newSpan.className="normalSpan";newSpan.innerHTML=action_messages[i];newDiv.appendChild(newSpan);messageDiv.appendChild(newDiv);}}}
function processExecuteActions(_execIndex){var scriptFinderPattern=/\<script[^\>]+javascript[^\>]*\>\s*([\s\S]*?)\s*\<\s*\/\s*script/gi;if(executeActionUrls&&executeActionUrls.length>_execIndex){var callback={success:function(response){if(response.responseText.length>0){SetRedirDelay(-1);var results=response.responseText.split("<!--*EXECUTE*-->");for(var _i=results.length-1;_i>=0;_i--){var pos=_i-1;if(results[_i].length>0){var scriptMatch=scriptFinderPattern.exec(results[_i]);while(scriptMatch){eval(scriptMatch[1]);scriptMatch=scriptFinderPattern.exec(results[_i]);}
var placeholderDiv=document.getElementById("execute"+pos);if(placeholderDiv){placeholderDiv.innerHTML=results[_i];placeholderDiv.style.display="block";}
else{var newDiv=document.createElement("div");newDiv.innerHTML=results[_i];switch(pos){case 1:var heads=document.getElementsByTagName("head");if(heads.length>0){var t=document.createTextNode(results[_i]);heads[0].appendChild(t);}
break;case-1:case 0:case 2:case 3:case 4:case 5:case 6:case 7:case 8:document.body.insertBefore(newDiv,document.body.firstChild);break;case 9:document.body.appendChild(newDiv);break;}}}}}
processExecuteActions(_execIndex+1);},timeout:30000,failure:function(response){processExecuteActions(_execIndex+1);}};var transaction=YAHOO.util.Connect.asyncRequest('GET',executeActionUrls[_execIndex],callback,null);}
else{issueRedirect();}}
function issueRedirect(target){if(isNaN(redir_delay)){redir_delay=0;}
if(redir_delay>0){setTimeout(function(){_doRedirect(target);},(redir_delay*1000));}
else if(redir_delay==0){_doRedirect(target);}}
function _doRedirect(target){if(redir_url.length!=0){if(target&&target.location){target.location.href=redir_url;}
else{if(!(redir_target&&redir_target.length>0))
{if((parent&&parent.name=='AngelContent')||(parent&&this.name.indexOf('win')==0)){parent.location.href=redir_url;}
else
{location.href=redir_url;}}
else
{if(redir_target.toUpperCase()=='_SELF')
{location.href=redir_url;}
else if(redir_target.toUpperCase()=='_TOP')
{top.location.href=redir_url;}
else if(redir_target.toUpperCase()=='_PARENT')
{if(parent)
{parent.location.href=redir_url;}
else
{location.href=redir_url;}}
else if(redir_target.toUpperCase()=='_BLANK')
{window.open(redir_url,"Redirect");}
else
{var testframe=window.document.getElementById(redir_target);if(testframe&&testframe.contentWindow)
{testframe.contentWindow.location.href=redir_url;}
else if(redir_target.toUpperCase()=='ANGELCONTENT')
{testframe=top.document.getElementById('contentWin');if(testframe&&testframe.contentWindow)
{testframe.contentWindow.location.href=redir_url;}}
else
{testframe=top.document.getElementById(redir_target);if(testframe&&testframe.contentWindow)
{testframe.contentWindow.location.href=redir_url;}}}}}}}