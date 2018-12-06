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


  
  
  
  <!--Template: Template for the stock element-->
  <xsl:template match="sName/@symbol">
    <!-- <h3 id="symbol">name</h3> -->
    <h3 id="symbol">
      <xsl:value-of select="."/>
    </h3>
  </xsl:template>
  
  
  
  <xsl:template match="sName">
    <h3 id="symbol">
      <xsl:value-of select="."/>
    </h3>

      <xsl:value-of select="."/>
      <!--adding brackets means put the symbol value between brackets-->
      (<xsl:value-of select="@symbol"/>)
  </xsl:template>

  <xsl:template match="stock">
    <!--div means create a block-->
    <div>
      <xsl:apply-templates select="sName"/>
      <xsl:apply-templates select="today"/>
      <!--p means create a special paragraph for description-->
      <p>
        <xsl:value-of select="description"/>
      </p>
      <xsl:apply-templates select="five_day"/>
    </div>
  </xsl:template>

  <xsl:template match="sName">
    <h3>
      <xsl:value-of select="."/>
      <!--adding brackets means put the symbol value between brackets-->
      (<xsl:value-of select="@symbol"/>)
    </h3>
  </xsl:template>

  
  
  
  
  <!--Template: attribute template-->
  <!--Stock value tempalte: input is stock value attributes-->
  <!--Set the match attribute of this template to match any of the following stock value attributes in the source doucment:-->
  <xsl:template match="@current|@open|@high|@low|@vol|@category|@year_high|@year_low|@pe_ration|@earnings|@yield">
    <!--Where value is the value of the context node -->
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

</xsl:stylesheet>

