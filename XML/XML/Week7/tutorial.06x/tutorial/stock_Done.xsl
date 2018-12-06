<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Tutorial Case

   Hardin Financial XSL Style Sheet
   Author: Hazim Mohaisen
   Date:   06/02/2012

   Filename:         stock.xsl
   Supporting Files: down.gif, same.gif, stock.css, up.gif

-->
<!-- pg305 -->



<!--Can use xsl:Transform instead of xsl:stylesheet  below"-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!--Declares for the browser what kind of output whether it's an xml at the end or an html document.  This will be an html document of verion 4.0-->
  <!-- Specify the output format of the result document pg 314 -->
  <!--Here we are saying the output document should be formatted as an html version 1 -->
  <xsl:output method="html" version="1.0"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Stock Information</title>
        <link href="stock.css" rel="stylesheet" type="text/css" />
      </head>
      <body>
        <div id="datetime">
          <b>Last Updated:</b>
          <xsl:value-of select="portfolio/date"/> at
          <xsl:value-of select="portfolio/time"/>
        </div>
        <h1>Hardin Financial</h1>
        <h2>Stock Information</h2>

        <xsl:apply-templates select="portfolio/stock"/>

        <!--<xsl:for-each select="portfolio/stock">
          <h3>
            --><!--xsl:value-of select="portfolio/stock/sName"/--><!--
            <xsl:value-of select="sName"/>
          </h3>
        </xsl:for-each>-->


      </body>
    </html>
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

  <xsl:template match="today">
    <!-- This table will create this in the row in the form of a row:
    Current Open High Low volume 
    -->
    <table>
      <tr>
        <th>Current</th>
        <th>Open</th>
        <th>High</th>
        <th>Low</th>
        <th>volume</th>
      </tr>
      <tr>
        <xsl:apply-templates select="@current"/>
        <xsl:apply-templates select="@open"/>
        <xsl:apply-templates select="@high"/>
        <xsl:apply-templates select="@low"/>
        <xsl:apply-templates select="@vol"/>
      </tr>
    </table>
  </xsl:template>
  
  <xsl:template match="five_day">
    <table>
      <tr>
        <th colspan="6">Recent History</th>
      </tr>
      <tr>
        <th>Day</th>
        <th>Open</th>
        <th>High</th>
        <th>Low</th>
        <th>Close</th>
        <th>Volume</th>
      </tr>
      <xsl:apply-templates select="day"/>
    </table>
  </xsl:template>

  <xsl:template match="day">
    <tr>
      <xsl:apply-templates select="@date"/>
      <xsl:apply-templates select="@open"/>
      <xsl:apply-templates select="@high"/>
      <xsl:apply-templates select="@low"/>
      <xsl:apply-templates select="@close"/>
      <xsl:apply-templates select="@vol"/>
    </tr>
  </xsl:template>
  
  <xsl:template match="@current|@open|@high|@low|@vol|@date|@close">
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

</xsl:stylesheet>