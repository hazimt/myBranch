<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Review Assignment

   Hardin Financial XSL Style Sheet
   Author: Hazim Mohaisen
   Date:   05/23/2012

   Filename:         stock2.xsl
   Supporting Files: down.gif, same.gif, stock2.css, up.gif

-->

<!--Setup this document as an XSLT style sheet by-->
<!--adding a stylesheet root element and declaring the XSLT namespace using namespace xsl-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
  <!-- Add an output element with a method attribute to tell the xslt processor that result doucment should conform to the html version 1.0-->
  <xsl:output method="html" version="1.0"/>

  <!--Create a root template-->
  <xsl:template match="/">

    <!--sending the literal result elements to the result document-->
    <html>
      <head>
        <title>Stock Information</title>
        <link href="stock2.css" rel="stylesheet" type="text/css"/>
      </head>
      <body>
        <!--in the root element -->
        <div id="datetime">
          As of date at time
          <xsl:value-of select="portfolio/date"/> at
          <xsl:value-of select="portfolio/time"/>
        </div>


      </body>
    </html>

  </xsl:template>
  <!--End of root template-->

</xsl:stylesheet>

