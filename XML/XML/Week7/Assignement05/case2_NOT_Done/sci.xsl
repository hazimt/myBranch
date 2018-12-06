<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Case Problem 2

   SciNews XSLT Style Sheet
   Author: Hazim Mohaisen
   Date:   06/16/2012


   Filename:         sci.xsl
   Supporting Files: back.jpg, home.htm, links.jpg, nasa.htm, neptune.htm,
                     sci.css, scitimes.jpg, side.jpg, vm.htm, whales.htm

-->

<!--Step 3-->
<!--Setup the document as an XSLT by -->
<!--Adding a style sheet root element-->
<!--and declaring the XSLT namespace using the namespace prefix xsl-->
<!--Declare an RSS namespace having a URI of http://purl.org/dc/elements/1.1/ and a namespace prefix of dc-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:dc="http://purl.org/dc/elements/1.1/">

  <xsl:output method="html" version="4.0"/>
  <!--Step 4-->
  <!--Create Root element containing -->
  <xsl:template match="/">
    <html>
      <head>
        <title>
          <!--Title is the value of the title element in the source document (rss2.xml), located as a child of the channel element-->
          <xsl:value-of select="rss/channel/title"/>
        </title>
        <link rel="stylesheet" href="sci.css"/>
      </head>
      <body>
        <!--Step 6-->
        <!--<div id="logo">image</div>-->
        <div id="logo">
          <xsl:apply-templates select="rss/channel/image"/>
        </div>
        <!--Step 7-->
          <!--<div id="datetime">date</div>-->
          <div id="datetime">
            <xsl:value-of select="rss/channel/dc:date"/>
            <!--<xsl:value-of select="//*[local-name(.)='date']"/>-->
          </div>
          <!--Step 8-->
        <!--Description of the news source-->
          <div id="links">
            <p>
              <xsl:value-of select="rss/channel/description"/>
            </p>
            <p>
              <img src="links.jpg"/>
            </p>
          </div>
        <!--Step 10-->
        <div id="news">
          <h1>RSS News Feed</h1>
          <!--apply item element-->
          <xsl:apply-templates select="rss/channel/item"/>
        </div>
      </body>
    </html>
  </xsl:template>

  <!--Step 5-->
  <xsl:template match="image">
    <!--<a href="link">-->
      <!--<img src="url" alt="title" width="width" height="height" longdesc="description"/>-->
    <!--Where link is the value of the link element within the image element of the source document (the source document is rss2.xml)-->
    <!-- <a href="http://wwww.wasdf.com">someName</a>  and 
          where link=http://wwww.wasdf.com
          someName=<xsl:value-of select="../link"/> 
          href="{../link}">
          -->
    <!--<a href="{//link}">-->
    <a href="{//link}">
      <img src="{//url}" alt="{//title}" width="{//width}" height="{//height}" longdesc="{//description}"/>
    </a>
  </xsl:template>
  
  <!--Step 9-->
  <xsl:template match="item">
    <!--<h2>title</h2>
    <p id="subjtime">subject / pubDate</p>
    <p>description</p>
    <p id="itemlink"> [ <a href="link">more</a> J </p>-->

    <h2>
      <!--<xsl:value-of select="rss/channel/item/title"/>-->
      <xsl:value-of select="title"/>
    </h2>
    <p id="subjtime">
      <!--<xsl:value-of select="rss/channel/item/dc:subject"/> / 
      <xsl:value-of select="rss/channel/item/dc:pubDate"/>-->
      <xsl:value-of select="dc:subject"/> /
      <xsl:value-of select="dc:pubDate"/>
    </p>
    <p>
      <!--Also correct-->
      <!--<xsl:value-of select="rss/channel/item/description"/>-->
      <xsl:value-of select="description"/>
    </p>
    <p id="itemlink">
      [
      <a href="{//item/link}"> 
        more
      </a>
      ]
    </p>
  </xsl:template>

</xsl:stylesheet>
