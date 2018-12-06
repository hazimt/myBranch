<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Case Problem 2

   SciNews XSLT Style Sheet
   Author: Adrian Balasa
   Date:   06/05/2012

   Filename:         sci.xsl
   Supporting Files: back.jpg, home.htm, links.jpg, nasa.htm, neptune.htm,
                     sci.css, scitimes.jpg, side.jpg, vm.htm, whales.htm

-->
<xsl:stylesheet  version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                               xmlns:dc="http://purl.org/dc/elements/1.1/">
    <xsl:output method="html" version="4.0"/>
    <xsl:template match="/">
        <html>
            <head>
                <title>
                    <xsl:value-of select="rss/channel/title"/>
                </title>
                <link href="sci.css" rel="stylesheet" type="text/css"/>
            </head>
            <body>
                <div id="logo">
                    <xsl:apply-templates select="rss/channel/image"/>




                </div>
                <div id="datetime">
                    <xsl:value-of select="//*[local-name(.)='date']"/>
                </div>
                <div id="links">
                    <p>
                        <xsl:value-of select="description"/>
                    </p>
                    <p>
                        <img src="links.jpg"/>
                    </p>
                </div>
                <div id="news">
                    <h1>RSS News Feed</h1>
                    <xsl:apply-templates select="rss/channel/item"/>
                   

                </div>
            </body>
        </html>
    </xsl:template>
    <xsl:template match="image">
        <a href="{//link}">
           
            <img src="{//url}" alt="{//title}" width="{//width}" height="{//height}" longdesc="{//description}"/>
          
  
</a>
    </xsl:template>
    <xsl:template match="item">
        <h2>
            <xsl:value-of select="title"/>
        </h2>
        <p id="subjtime">
            <xsl:value-of select="dc:subject"/> / 
            <xsl:value-of select="//*[local-name(.)='pubDate']"/>
        </p>
        <p>
            <xsl:value-of select="description"/>
        </p>
        <p id="itemlink">
            [
            <a href="{//item/link}">
                more
            </a>]
    </p>
    </xsl:template>
    
</xsl:stylesheet>

