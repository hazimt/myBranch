	// FCKeditor Class
	var FCKeditor=function( instanceName, width, height, toolbarSet, value )
	{
		// Properties
		this.InstanceName=instanceName;
		this.Width=width||'100%';
		this.Height=height||'200';
		this.ToolbarSet=toolbarSet||'Default';
		this.Value=value||'';
		this.BasePath=FCKeditor.BasePath;
		this.CheckBrowser=true;
		this.DisplayErrors=true;
		this.Config=new Object();
		this.OnError=null;
	}

	FCKeditor.BasePath='/inlineeditor/';

	FCKeditor.MinHeight=50;

	FCKeditor.MinWidth=250;

	FCKeditor.prototype.Version='2.6 RC';

	FCKeditor.prototype.VersionBuild='18531';

	FCKeditor.prototype.Create=function()
	{
		document.write( this.CreateHtml() );
	}

	FCKeditor.prototype.CreateHtml=function()
	{
		// Check for errors
		if ( !this.InstanceName ||this.InstanceName.length==0 )
		{
			this._ThrowError( 701, 'You must specify an instance name.' );
			return '';
		}

		var sHtml='';

		if ( !this.CheckBrowser ||this._IsCompatibleBrowser() )
		{
			sHtml +='<input type="hidden" id="' + this.InstanceName + '" name="' + this.InstanceName + '" value="' + this._HTMLEncode( this.Value ) + '" style="display:none" />';
			sHtml +=this._GetConfigHtml();
			sHtml +=this._GetIFrameHtml();
		}
		else
		{
			var sWidth =this.Width.toString().indexOf('%')  > 0 ? this.Width  : this.Width  + 'px';
			var sHeight=this.Height.toString().indexOf('%') > 0 ? this.Height : this.Height + 'px';
			sHtml +='<textarea name="' + this.InstanceName + '" rows="4" cols="40" style="width:' + sWidth + ';height:' + sHeight + '">' + this._HTMLEncode( this.Value ) + '<\/textarea>';
		}

		return sHtml;
	}

	FCKeditor.prototype.ReplaceTextarea=function()
	{
		if ( !this.CheckBrowser ||this._IsCompatibleBrowser() )
		{
			// We must check the elements firstly using the Id and then the name.
			var oTextarea=document.getElementById( this.InstanceName );
			var colElementsByName=document.getElementsByName( this.InstanceName );
			var i=0;
			while ( oTextarea ||i==0 )
			{
				if ( oTextarea && oTextarea.tagName.toLowerCase()=='textarea' )
					break;
				oTextarea=colElementsByName[i++];
			}

			if ( !oTextarea )
			{
				alert( 'Error: The TEXTAREA with id or name set to "' + this.InstanceName + '" was not found' );
				return;
			}

			if (this.Width.toString().indexOf('%')==-1)
				this.Width=Math.max( oTextarea.offsetWidth, FCKeditor.MinWidth );

			if (this.Height.toString().indexOf('%')==-1)
				this.Height=Math.max( oTextarea.offsetHeight, FCKeditor.MinHeight );

			//now check if the space is big enough for the toolbar buttons and if not, resize to fit and collapse the toolbar
			var pixelWidth = (this.Width.toString().indexOf('%')==-1)?this.Width:oTextarea.offsetWidth;
			var pixelHeight = (this.Height.toString().indexOf('%')==-1)?this.Height:oTextarea.offsetHeight;
			var btnHeight = 25;
			var btnWidth = 25;
			var minButtons = (this.ToolbarSet=='Full')?35:(this.ToolbarSet=='Default')?20:(this.ToolbarSet=='ViewOnly')?2:15;
			var minEditArea = 25;
			var btnPerRow = parseInt(pixelWidth/btnWidth);
			if (parseInt(pixelHeight/btnHeight)*btnPerRow<minButtons) {
				this.Config['ToolbarStartExpanded'] = false;
				this.Height = parseInt((parseInt(minButtons/btnPerRow)+1.25)*btnHeight)+minEditArea;
			}

				
			oTextarea.style.display='none';
			this._InsertHtmlBefore( this._GetConfigHtml(), oTextarea );
			this._InsertHtmlBefore( this._GetIFrameHtml(), oTextarea );
		}
	}

	FCKeditor.prototype._InsertHtmlBefore=function( html, element )
	{
		if ( element.insertAdjacentHTML )	// IE
			element.insertAdjacentHTML( 'beforeBegin', html );
		else								// Gecko
		{
			var oRange=document.createRange();
			oRange.setStartBefore( element );
			var oFragment=oRange.createContextualFragment( html );
			element.parentNode.insertBefore( oFragment, element );
		}
	}

	FCKeditor.prototype._GetConfigHtml=function()
	{
		var sConfig='';
		for ( var o in this.Config )
		{
			if ( sConfig.length > 0 ) sConfig +='&amp;';
			sConfig +=encodeURIComponent( o ) + '=' + encodeURIComponent( this.Config[o] );
		}

		return '<input type="hidden" id="' + this.InstanceName + '___Config" value="' + sConfig + '" style="display:none" />';
	}

	FCKeditor.prototype._GetIFrameHtml=function()
	{
		var sFile='fckeditor.html';

		try
		{
			if ( (/fcksource=true/i).test( window.top.location.search ) )
				sFile='fckeditor.original.html';
		}
		catch (e) { /* Ignore it. Much probably we are inside a FRAME where the "top" is in another domain (security error). */ }

		var sLink=this.BasePath + 'editor/' + sFile + '?InstanceName=' + encodeURIComponent( this.InstanceName );
		if (this.ToolbarSet) sLink +='&amp;Toolbar=' + this.ToolbarSet;

		return '<iframe id="' + this.InstanceName + '___Frame" src="' + sLink + '" width="' + this.Width + '" height="' + this.Height + '" frameborder="0" scrolling="no"></iframe>';
	}

	FCKeditor.prototype._IsCompatibleBrowser=function()
	{
		return FCKeditor_IsCompatibleBrowser();
	}

	FCKeditor.prototype._ThrowError=function( errorNumber, errorDescription )
	{
		this.ErrorNumber=errorNumber;
		this.ErrorDescription=errorDescription;

		if ( this.DisplayErrors )
		{
			document.write( '<div style="COLOR: #ff0000">' );
			document.write( '[ FCKeditor Error ' + this.ErrorNumber + ': ' + this.ErrorDescription + ' ]' );
			document.write( '</div>' );
		}

		if ( typeof( this.OnError )=='function' )
			this.OnError( this, errorNumber, errorDescription );
	}

	FCKeditor.prototype._HTMLEncode=function( text )
	{
		if ( typeof( text ) !="string" )
			text=text.toString();

		text=text.replace(
			/&/g, "&amp;").replace(
			/"/g, "&quot;").replace(
			/</g, "&lt;").replace(
			/>/g, "&gt;");

		return text;
	}

	function FCKeditor_IsCompatibleBrowser()
	{
		var sAgent=navigator.userAgent.toLowerCase();

		// Internet Explorer 5.5+
		if ( /*@cc_on!@*/false && sAgent.indexOf("mac")==-1 )
		{
			var sBrowserVersion=navigator.appVersion.match(/MSIE (.\..)/)[1];
			return ( sBrowserVersion >=5.5 );
		}

		// Gecko (Opera 9 tries to behave like Gecko at this point).
		if ( navigator.product=="Gecko" && navigator.productSub >=20030210 && !( typeof(opera)=='object' && opera.postError ) )
			return true;

		// Opera 9.50+
		if ( window.opera && window.opera.version && parseFloat( window.opera.version() ) >=9.5 )
			return true;

		// Adobe AIR
		// Checked before Safari because AIR have the WebKit rich text editor
		// features from Safari 3.0.4, but the version reported is 420.
		if ( sAgent.indexOf( ' adobeair/' ) !=-1 )
			return ( sAgent.match( / adobeair\/(\d+)/ )[1] >=1 );	// Build must be at least v1

		// Safari 3+
		if ( sAgent.indexOf( ' applewebkit/' ) !=-1 )
			return ( sAgent.match( / applewebkit\/(\d+)/ )[1] >=522 );	// Build must be at least 522 (v3)

		return false;
	}


if (!window.fckANGEL) {
	window.fckANGEL = {};
	fckANGEL.onload = function()
	{
		if (!_angelConfig.activate) { return; }
		var collTextAreas=document.getElementsByTagName('textarea');
		for (var i=0;i<collTextAreas.length;i++) 
		{
			var sStylesheet="";
			var sBaseHref='';
			var sToolbarSet="Default";
			var bConvert=(collTextAreas[i].getAttribute('tb')||collTextAreas[i].getAttribute('tboptions'))?true:false;
			if (bConvert)
			{
				var ta = collTextAreas[i];
				var sID=(ta.id&&ta.id !='') ? ta.id : ta.getAttribute('name');
				var h=(ta.offsetHeight&&ta.offsetHeight>0)?ta.offsetHeight:(ta.getAttribute('rows'))?parseInt(ta.getAttribute('rows'))*25:30;
				var w=(ta.style.width&&ta.style.width.indexOf('%')!=-1)?ta.style.width:(ta.offsetWidth&&ta.offsetWidth>0)?ta.offsetWidth:'100%';
				if (collTextAreas[i].getAttribute('tboptions')) { sToolbarSet=collTextAreas[i].getAttribute('tboptions'); }
				if (collTextAreas[i].getAttribute('tb')) { sToolbarSet=collTextAreas[i].getAttribute('tb'); }
				sTBLink='';
				if (collTextAreas[i].getAttribute('tblink')) { sTBLink=';tblink='+collTextAreas[i].getAttribute('tblink')+';'; }
				fckANGEL.convertTextArea(collTextAreas[i],'tb='+sToolbarSet+';tbbase='+sBaseHref+sTBLink,'',sStylesheet,'');
			}
		}
	}

	fckANGEL.processEditorOption = function(ed,n,v)
	{
		var c=ed.Config;
		if (n=='tb'&&v!=''&&v!=null)
			ed.ToolbarSet1=v;
		else if (n=='tbbase'&&v!=''&&v!=null)
			c['BaseHref']=v;
		else if (n=='tbvisible'&&v!=''&&v!=null)
			c['ToolbarStartExpanded']=(v=='true')?true:false;
		else if (n=='tbfullpage'&&v!=''&&v!=null)
			c['FullPage']=(v=='true')?true:false;
		else if (n=='height'&&v!=''&&v!=null)
			oFCKeditor.Height=parseInt(v);
		else if (n=='width'&&v!=''&&v!=null)
			oFCKeditor.Width=parseInt(v);
		else if (n=='tblocation'&&v!=''&&v!=null)
			c['ToolbarLocation']=v;
		else if (n=='tbbrowse'&&v!=''&&v!=null)
			c['BrowseFiles']=(v=='true')?true:false;
		else if (n=='tbupload'&&v!=''&&v!=null)
			c['UploadFiles']=(v=='true')?true:false;
		else if (n=='tblink'&&v!=''&&v!=null)
			c['HTMLLink']=(v=='true')?'true':'false';
		else
			return (v==''||v==null);
		return true;
	}
	
	fckANGEL.getToolbarSet = function(el,ts)
	{
		var sTB=el.getAttribute('tb');
		if (sTB&&sTB!=''&&sTB!=null)
			return sTB;
		if (el.getAttribute('tboptions')) 
		{
			var a=el.getAttribute('tboptions').split(';');
			for (var j=0;j<a.length;j++) 
			{
				var eq=a[j].indexOf('=');
				if (eq!=-1)
				{
					var n=a[j].substr(0,eq);
					var v=a[j].substr(eq+1,a[j].length);
					if (n=='tb'&&v!='')
					return v;
				}
			}
		}
		return (ts)?ts:'Default';
	}
		
	fckANGEL.parseEditorOptions = function(op,ed)
	{
		var a=op.split(';');
		for (var j=0;j<a.length;j++) 
		{
			var nEq=a[j].indexOf('=');
			if (nEq!=-1)
			{
				var n=a[j].substr(0,nEq);
				var v=a[j].substr(nEq+1,a[j].length);
				if (!fckANGEL.processEditorOption(ed,n,v))
					alert('Unknown setting: '+n+'='+v);
			}
		}
	}
	
	fckANGEL.convertClick = function(le,idx) {
		var el=le.parentNode;
		while((el=el.previousSibling)!=null)
			if(el.tagName&&el.tagName.toLowerCase()=='textarea')
				break;
		var p=window.arrEditorParams[idx];
		var convert = function() { fckANGEL.convertTextArea(el, p.options, p.toolbarSet, p.stylesheet, p.baseHref, true); };
		if(!el.disabled&&!el.getAttribute('readOnly')){
			if (le) le.style.display='none';
			setTimeout(convert,0);
		}
	}

	fckANGEL.convertTextArea = function(ta, op, ts, css, base, bIgnoreLink) {
	    if (!ta.id && !ta.getAttribute) { ta = document.getElementById(ta); }
	    if (ta.disabled || ta.getAttribute('readOnly')) { return; }
	    var sID = (ta.id && ta.id != '') ? ta.id : ta.getAttribute('name');
	    var h = (ta.offsetHeight && ta.offsetHeight > 0) ? ta.offsetHeight : (ta.getAttribute('rows')) ? parseInt(ta.getAttribute('rows')) * 25 : 30;
	    var w = (ta.style.width && ta.style.width.indexOf('%') != -1) ? ta.style.width : (ta.offsetWidth && ta.offsetWidth > 0) ? ta.offsetWidth : '100%';
	    var sToolbar = (ts && ts != '') ? ts : fckANGEL.getToolbarSet(ta);

	    var ed = new FCKeditor(sID, w, h, sToolbar);
	    ed.Config['CustomConfigurationsPath'] = _angelConfig.editorBase + 'extensions/config.js';
	    ed.BasePath = _angelConfig.editorBase;

	    ed.Config['HTMLLink'] = '' + _angelConfig.linkDefault;

	    if (css && css != '') { ed.Config['EditorAreaCSS'] = css; }
	    else if (window.gstrStylesheet && window.gstrStylesheet != '') { ed.Config['EditorAreaCSS'] = window.gstrStylesheet; }

	    if (base && base != '') { ed.Config['BaseHref'] = base; }
	    else if (window.gstrBaseHref && window.gstrBaseHref != '') { ed.Config['BaseHref'] = window.gstrBaseHref; }
	    else { ed.Config['BaseHref'] = _angelConfig.sessionBasePath; }

	    //Process tboptions
	    if (op && op != '') { fckANGEL.parseEditorOptions(op, ed); }
	    if (ta.getAttribute('tboptions')) { fckANGEL.parseEditorOptions(ta.getAttribute('tboptions'), ed); }
	    if (!bIgnoreLink && ('true' == ed.Config['HTMLLink'])) {
	        try {
	            if (!window.arrEditorParams) { arrEditorParams = []; }
	            var i = arrEditorParams.length;
	            arrEditorParams[i] = { id: sID, options: op, toolbarSet: ts, stylesheet: css, baseHref: base };
	            var oLink = document.createElement("a");
	            oLink.id = "link" + sID;
	            oLink.setAttribute("href", "javascript:void(0);")
	            oLink.setAttribute("target", "_self")
	            var clickFunc = function(oLink) { return function() { fckANGEL.convertClick(oLink, i); } };
	            // IE (onclick attribute works for template copy only)
	            if (!oLink.addEventListener && oLink.attachEvent)
	                oLink.attachEvent("onclick", clickFunc(oLink));
	            oLink.setAttribute("onClick", "fckANGEL.convertClick(this," + i + ");")
	            oLink.innerHTML = _angelConfig.linkLabel;
	            var oDiv = document.createElement("div");
	            oDiv.className = "htmled_link_container"
	            oDiv.appendChild(oLink);
	            ta.parentNode.insertBefore(oDiv, ta.nextSibling);
	        } catch (e) { alert(e); }
	    }
	    else {
	        ta.setAttribute('readOnly','1');
	        if (ta.getAttribute('tbbase')) { fckANGEL.processEditorOption(ed, 'tbbase', ta.getAttribute('tbbase')); }
	        if (ta.getAttribute('tbvisible')) { fckANGEL.processEditorOption(ed, 'tbvisible', ta.getAttribute('tbvisible')); }
	        if (ta.getAttribute('tbfullpage')) { fckANGEL.processEditorOption(ed, 'tbfullpage', ta.getAttribute('tbfullpage')); }
	        ed.Height += (ed.Config['ToolbarStartExpanded']) ? 20 : 10;
	        ed.Config['FullPage'] = (ed.Config['FullPage'] || ta.value.match(/<html/gi)) ? true : false;
	        ed.ReplaceTextarea();
	    }
	}


	/****************************************************************************************/
	// Cross-browser implementation of element.addEventListener()
	if (!window.addListener) {
		window.addListener = function(element, type, expression, bubbling) {
			bubbling = bubbling || false;
			if(window.addEventListener)	{ // Standard
				element.addEventListener(type, expression, bubbling);
				return true;
			} else if(window.attachEvent) { // IE
				element.attachEvent('on' + type, expression);
				return true;
			} else
				return false;
		}
	}

	function switchEditors(oNode) {
		var i=0;
		for (i=0;i<oNode.childNodes.length;i++) {
			childNode=oNode.childNodes.item(i);
			editor=(window.FCKeditorAPI)?FCKeditorAPI.GetInstance(childNode.name):null;
			if (editor&&editor.EditorDocument&&editor.EditMode==FCK_EDITMODE_WYSIWYG) {
				oNode.style.display='none';
				oNode.style.display='block';
				editor.EditorDocument.designMode="on";
				setTimeout("FCKeditorAPI.GetInstance('"+editor.Name+"').SwitchEditMode();",100);
				setTimeout("FCKeditorAPI.GetInstance('"+editor.Name+"').SwitchEditMode();",200);
			}
			switchEditors(childNode);
		}
	}
	//we have to override the setDisplay (normal/advance toggle) in mozilla to fix loss of designMode setting
	if (window.setDisplay&&!document.all) {
		setDisplay=function(sIdList,sDisplay)
		{
			var arrList=new Array();
			if (sIdList.indexOf(',')!=-1)
				arrList=sIdList.split(',');
			else
				arrList[0]=sIdList;
			var nStart=0;
			var nLimit=arrList.length;
			var nInc=1;
			if (sDisplay!='none') {
				nStart=arrList.length-1;
				nLimit=-1;
				nInc=-1;
			}
			for (var x=nStart;x!=nLimit;x+=nInc)
			{
				if (arrList[x] !='') {
					var oElem=document.getElementById(arrList[x]);
					if (oElem) {
						oElem.style.display=sDisplay;
						if (sDisplay=='block') {switchEditors(oElem);}
				}
			}
			}
		}
	}

	// make some global vars for accessing the editor
	var oFCK=null;
	var oEditor=null;
	var sBrowseTargetId=null;
	var bLoading = false;

	function OpenFileBrowser(sTarget,sType)
	{
		if(typeof(oEditor) == 'undefined' || oEditor == null)
		{
			//user in HTML_LINK_ONLY mode - need to load editor before displaying dialog
			var a = document.getElementsByTagName('a');
			for (var i=0;i<a.length;i++) 
			{
				var linkID;
				try
				{
				    linkID = a[i].getAttribute("id");
				} catch(err) {
				    //Not the HTML Editor link
				    continue;
				}
				if(linkID == "linkPAGE_TEXT")
				{
					break;
				}
			}
			if(i < a.length)
			{
				if(bLoading == false)
				{
					fckANGEL.convertClick(a[i],0);
					bLoading = true;
				}
				setTimeout("OpenFileBrowser('" + sTarget + "', '" + sType + "')", 500);
			}
			return;
		}
		// oEditor must be defined.
		var url=(sType=='Image')?oEditor.FCKConfig.ImageBrowserURL:oEditor.FCKConfig.LinkBrowserURL;
		var width=(sType=='Image')?oEditor.FCKConfig.ImageBrowserWindowWidth:oEditor.FCKConfig.LinkBrowserWindowWidth;
		var height=(sType=='Image')?oEditor.FCKConfig.ImageBrowserWindowHeight:oEditor.FCKConfig.LinkBrowserWindowHeight;
		var iLeft=(oEditor.FCKConfig.ScreenWidth  - width) / 2;
		var iTop=(oEditor.FCKConfig.ScreenHeight - height) / 2;
		var sOptions="toolbar=no,status=no,resizable=yes,dependent=yes,scrollbars=yes";
		sOptions+=",width="+width;
		sOptions+=",height="+height;
		sOptions+=",left="+iLeft;
		sOptions+=",top="+iTop;

		//store which textbox we are browsing for
		sBrowseTargetId=sTarget;
		if (oEditor&&oEditor.FCKConfig.PreserveSessionOnFileBrowser&&oEditor.FCKBrowserInfo.IsIE)
		{
			var oWindow=oEditor.window.open(url,'FCKBrowseWindow',sOptions);
			if (oWindow) {
				try {
					var sTest=oWindow.name;
					oWindow.opener=window;
				} catch(e) {alert(oEditor.FCKLang.BrowseServerBlocked);}
			} else {alert(oEditor.FCKLang.BrowseServerBlocked);}
		} else {window.open(url,'FCKBrowseWindow',sOptions);}
	}

	function SetUrl (url,width,height,alt)
	{
		url=oFCK.TokenizePaths(oFCK.Config,url,false,true);
		var oElem=document.getElementById(sBrowseTargetId);
		if (oElem) {oElem.value=url;}
	}

	//get a reference to the first editor for use by browse links
	if (!window.FCKeditor_OnComplete_orig)
	{
		window.FCKeditor_OnComplete_orig = (typeof(FCKeditor_OnComplete)=='function')?FCKeditor_OnComplete:function(){};
		FCKeditor_OnComplete=function(FCK) 
		{
			if (!oFCK) {oFCK=FCK;}
			if (!oEditor) {oEditor=document.getElementById(oFCK.Name+'___Frame').contentWindow.window;}
			window.FCKeditor_OnComplete_orig(FCK);
		}
	}

    if (!window.linkClick) {
	    window.linkClick = function(e) {
	        try {
		        var ev = (window.event)?window.event:e;
		        var el = (ev.srcElement)?ev.srcElement:(ev.target)?ev.target:null;
                var link = false;
		        if (el && el.tagName && el.tagName.toLowerCase()=="a") 
                {
                    link = true;
                }
                else 
                {
                    while(link == false && el && el.parentNode != null && el.parentNode != el)
                    {
                        if(el && el.parentNode.tagName && el.parentNode.tagName.toLowerCase()=="a")
                        {
                            link = true;
                        }
                        el = el.parentNode
                    }
                }

                if(link)
		        {
			        if(typeof(el.onclick) != 'function') {
				        var href = el.getAttribute("href");
				        var lhref = href.toLowerCase();
				        if (lhref.indexOf("wci=goto")!=-1 || 
					        lhref.indexOf("/permalink.aspx")!=-1){
					        //this is a goto or perma link
					        if(el.target.length == 0) {
						        el.target = "AngelContent";
					        }						
				        }
				        else if (href.substr(0,1) == '#' ||
						         href.indexOf(document.getElementsByTagName("base")[0].href + '#') != -1) {
					        //this is a hash (local) link
					        document.location.hash=el.href.substr(el.href.indexOf('#'), el.href.length);
					        if (e && e.preventDefault) {
						        e.preventDefault(); // DOM style
					        }
					        return false;
				        }
			        }
		        }
	        } catch(e) {}
        }
    }

	addListener(window, "load", fckANGEL.onload, true);
	addListener(document, "click", linkClick, true);
}