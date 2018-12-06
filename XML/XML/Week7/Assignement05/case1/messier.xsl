<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Case Problem 1

   Messier Objects XSLT Style Sheet
   Author: Hazim Mohaisen
   Date:   05/23/2012

   Filename:         messier.xsl
   Supporting Files: m01.jpg, m13.jpg, m16.jpg, m20.jpg, m27.jpg, m31.jpg,
                     m42.jpg, m51.jpg, m57.jpg, skyweb.css, skyweb.jpg
-->
<!--Step 3-->
<!--Can use xsl:Transform instead of xsl:stylesheet  below"-->
<!--Setup this document as an XSLT style sheet by adding a style sheet root element and declaring the XSLT namepsapce using the nsamespace prefix XSL-->
<!--Declare a stylesheet root element-->
<!--Declare the xslt namesapce-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!-- Add an output element with a method attribute that tells the xslt processor that result doucment should conform to the html version 1.0-->
  <xsl:output method="html" version="1.0"/>

  <!--Root tempalte: Write the following code to the result doucment-->
  <!--Create a root template-->
  <xsl:template match="/">

    <!--Step 4-->
    <!-- ================= Begin Code into result document ================= -->
    <!--This html code will be written to the result document-->
    <html>
      <head>
        <title>The Messier Objects</title>
        <!--these are called Literal result elements pg 311, 312-->
        <!---->
        <link href="skyweb.css" rel="stylesheet" type="text/css"/>
      </head>
      <body>
        <h1 id="logo">
          <img src="skyweb.jpg" alt="SkyWeb"/>
        </h1>

        <!--Step 10-->
        <h1>The Messier Objects</h1>
        <!--object-->
        <xsl:apply-templates select="messier/object">
          <xsl:sort select="@id"/>
        </xsl:apply-templates>
      </body>

    </html>
    <!-- ================= End Code into result document ================= -->

  </xsl:template>

  <!--Step 7-->
  <xsl:template match="messier/object">
    <!--<div>
      <h2>name (id)</h2>
      data
    </div>-->
    <div>
      <h2>
        <xsl:value-of select="name"/>
        (<xsl:value-of select="@id"/>)
      </h2>
      <!--Step 8-->
      <xsl:for-each select="description/p[1]">
        <!--<p><img src="id.jpg"/>p</p>-->
        <p>
          <img src="{../../@id}.jpg"/>
          <xsl:value-of select="."/>
        </p>
      </xsl:for-each>
      <!--Step 9-->
      <xsl:for-each select="description/p[position()>1]">
        <!--<p>p</p>-->
        <p>
          <xsl:value-of select="."/>
        </p>
      </xsl:for-each>

      <xsl:apply-templates select="data"/>
    </div>
  </xsl:template>
  
  <!--Step 6-->
  <!--Tempalte: Data element-->
  <xsl:template match="messier/object/data">
    
    <table border="5">
      <tr>
        <th>Distance (light years)</th>
        <th>Size (arc min)</th>
        <th>Magnitude</th>
        <th>Right Ascension</th>
        <th>Declination</th>
      </tr>
      <!--<tr>
        distance
        size
        mag
        ra
        dec
      </tr>
    </table>-->
      <tr>
        <!--Apply template in step 5-->
        <xsl:apply-templates select="distance"/>
        <xsl:apply-templates select="size"/>
        <xsl:apply-templates select="mag"/>
        <xsl:apply-templates select="ra"/>
        <xsl:apply-templates select="dec"/>
      </tr>
    </table>
  </xsl:template>

  <!--Step 5-->
  <!--Template: Writes a table cell containing information about each Messier object.  
  The template should amtch the follwoing elements: 
                      distance, size, mag, ra, and dec. 
  The template should write the following code-->
  <xsl:template match="distance|size|mag|ra|dec">
    <!--Where value is the value of the context node -->
    <td>
      <!--<td>value</td> where value is the value of the context node-->
      <xsl:value-of select="."/>
    </td>
  </xsl:template>


</xsl:stylesheet>

