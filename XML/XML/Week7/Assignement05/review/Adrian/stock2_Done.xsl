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

        <h1>Current Stock Values</h1>
        <table border="1" align="center" id="stocktable">
          <tr>
            <th>Stock</th>
            <th>Current</th>
            <th>Open</th>
            <th>High</th>
            <th>Low</th>
            <th>Volume</th>
          </tr>
          
          <!--today code generate by today template element-->
          <xsl:apply-templates select="portfolio/stock/today">
            <xsl:sort select="../sName/@symbol"/>
          </xsl:apply-templates>

        </table>

        <!--<h2 id="summary">Summary Information</h2>
        stock summary-->
        <h2 id="summary">Summary Information</h2>
        <!--stock summary-->
        <xsl:apply-templates select="portfolio/stock">
          <!--pg 338 sorting a node set-->
          <!-- Sort the rows in the five-day table -->
          <!--<xsl:sort select="sName/@symbol" order="descending"/>-->
          <xsl:sort select="sName/@symbol"/>
        </xsl:apply-templates>

      </body>
    </html>

  </xsl:template>
  <!--End of root template-->

  <!--Today Template-->
  <xsl:template match="today">
    <!--<tr>
      <td class="symbolcell">
        <a href="#symbol">symbol</a>
      </td>
      current
      open
      high
      low
      vol
    </tr>-->
    <tr>
      <td class="symbolcell">
        <!-- Applying a conditional Node -->
        <!--Conditional sytle created for the @current attribute -->
        <xsl:choose>
          <!--replace with the gif of an arrow if data/stock is going down-->
          <xsl:when test="@current &lt; @open">
            <img src="down.gif"/>
          </xsl:when>
          <xsl:when test="@current > @open">
            <img src="up.gif"/>
          </xsl:when>
          <xsl:otherwise>
            <img src="same.gif"/>
          </xsl:otherwise>
        </xsl:choose>
        <a href="#symbol">
          <xsl:value-of select="../sName/@symbol"/>
        </a>
      </td>
      <xsl:apply-templates select="@current"/>
      <xsl:apply-templates select="@open"/>
      <xsl:apply-templates select="@high"/>
      <xsl:apply-templates select="@low"/>
      <xsl:apply-templates select="@vol"/>
    </tr>
  </xsl:template>
  
  <!--Template: Stock Template for the stock element-->
  <xsl:template match="stock">
    <!-- <h3 id="symbol">name</h3> -->
    <xsl:apply-templates select="sName"/>

    <!--Create category table-->
    <table border="10" class="summtable">
      <tr>
        <th class="head2">Category</th>
        <xsl:apply-templates select="category"/>
      </tr>
      <tr>
        <th class="head2">Year high</th>
        <xsl:apply-templates select="year_high"/>
      </tr>
      <tr>
        <th class="head2">Year Low</th>
        <xsl:apply-templates select="year_low"/>
      </tr>
      <tr>
        <th class="head2">Earnings</th>
        <xsl:apply-templates select="earnings"/>
      </tr>
      <tr>
        <th class="head2">Yield</th>
        <xsl:apply-templates select="yield"/>
      </tr>
    </table>
    <!--<p>description</p> where description is the value of the description element-->
    <p>
      <xsl:value-of select="description"/>
    </p>
  </xsl:template>

  <xsl:template match="sName">
    <h3 id="symbol">
      <xsl:value-of select="."/>
    </h3>
  </xsl:template>

  <!--Template: attribute template-->
  <!--Stock value tempalte: input is stock value attributes-->
  <!--Set the match attribute of this template to match any of the following stock value attributes in the source doucment:-->
  <xsl:template match="@current|@open|@high|@low|@vol|category|year_high|year_low|pe_ration|earnings|yield">
    <!--Where value is the value of the context node -->
    <td>
      <!--<td>value</td>-->
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

</xsl:stylesheet>

