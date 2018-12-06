<?xml version="1.0" encoding="utf-8" ?>
<!--
  
   Author: Hazim Mohaisen
   Date:   6/18/2012 

-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!-- Add an output element with a method attribute that tells the xslt processor that result doucment should conform to the html version 1.0-->
  <xsl:output method="html" version="4.0"/>

  <!--Create a root template-->
  <xsl:template match="/">
    <xsl:variable name="mov" select="@movie"/>
    <xsl:variable name="act" select="@actor"/>
    <html>
      <head>
        <title>Catalog</title>
        <link href="catStyles.css" type="text/css" rel="stylesheet" />
      </head>
      <body>
        <h1>Catalog</h1>

        <h2>Movies</h2>
        <table>
          <tr>
            <th>Name</th>
            <th>Genre</th>
            <th>Year</th>
            <th>Length (in min.)</th>
          </tr>
          <!-- movie template applied here -->
          <xsl:apply-templates select="catalog/movies/movie">
            <xsl:sort select="title" />
          </xsl:apply-templates>
          <h4>
            <!--(moviecount movies total)-->
            (
            <xsl:value-of select="count($mov//movie)"/> 
            movies total)
          </h4>
        </table>

        <h2>Actors</h2>
        <table>
          <tr>
            <th>Name</th>
            <th>Roles</th>
          </tr>
          <!-- actor template applied here -->
          <xsl:apply-templates select="catalog/actors/actor">
            <xsl:sort select="name"/>
          </xsl:apply-templates>
          <h4>
            (
            <xsl:value-of select="count($act//actor)"/>
            movies total)
          </h4>
        </table>
      </body>
    </html>
    
  </xsl:template>

  <!--actor element-->
  <xsl:template match="actor">
    <tr>
      <!--name cell-->
      <td>
        <xsl:apply-templates select="name"/>
      </td>
      <td>
        <ul>
          <!--role-->
          <xsl:apply-templates select="role"/>
        </ul>
      </td>
    </tr>
    
  </xsl:template>

  <!--movie element-->
  <xsl:template match="movie">
    <!--<tr>
      title cell
      genre cell
      year cell
      length cell
    </tr>-->
    <tr>
      <td>
        <xsl:apply-templates select="title"/>
        <th>
          <xsl:apply-templates select="@genre"/>
        </th>
        <th>
          <xsl:apply-templates select="year"/>
        </th>
        <th>
          <xsl:apply-templates select="length"/>
        </th>
      </td>
    </tr>
  </xsl:template>

  <!--role element-->
  <xsl:template match="role">
    <!--step 8, b-->
    <xsl:variable name="mov" select="@movie"/>

    <li>
      <!--name in "movie name"-->
      <xsl:value-of select="."/> in 
      "<xsl:value-of select="../../../movies/movie[@movieId=$mov]/title"/>"
    </li>

  </xsl:template>

  <!--varying element-->
  <!--table cell template-->
  <xsl:template match="title|year|length|name|birthplace|@genre">
    <ttd>
      <!--value-->
      <xsl:value-of select="."/>
    </ttd>
  </xsl:template>
  
  
</xsl:stylesheet>