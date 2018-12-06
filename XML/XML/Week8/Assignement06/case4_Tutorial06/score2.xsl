<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Case Problem 4

   Baseball Abstract Box Score Style Sheet
   Author: Hazim Mohaisen
   Date:   06/11/2012

   Filename:         score.xsl
   Supporting Files: 
-->

<!--Step 2-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!-- Add an output element with a method attribute that tells the xslt processor that result doucment should conform to the html version 1.0-->
  <xsl:output method="html" version="1.0"/>

  <!--Root tempalte: Write the following code to the result doucment-->
  <!--Create a root template-->
  <xsl:template match="/">
    <html>
      <head>
        <!--<title>Minnesota at Boston</title>-->
      </head>
      <body>
        <h1>Minnesota at Boston</h1>
        <xsl:apply-templates select="boxscore/game"/>
        <xsl:apply-templates select="boxscore/team"/>
        <!--<xsl:apply-templates select="boxscore/name/team"/>-->

      </body>
    </html>
  </xsl:template>

  <xsl:template match="game">
    <!-- This table will create this in the row in the form of a row:
    Current Open High Low volume 
    -->
    <table>
      <tr>
        <th>Final</th>
        <th>1</th>
        <th>2</th>
        <th>3</th>
        <th>4</th>
        <th>5</th>
        <th>6</th>
        <th>7</th>
        <th>8</th>
        <th>9</th>
        <th>Runs</th>
        <th>Hits</th>
        <th>Errors</th>
      </tr>
      <tr>
      </tr>
    </table>
  </xsl:template>

  <xsl:template match="team">
    <table border="1">
      <caption style="text-align:center">
        <xsl:value-of select="name"/>
      </caption>
      <tr>
        <th colspan="9">Batters</th>
      </tr>
      <tr>
        <th>player</th>
        <th>AB</th>
        <th>R</th>
        <th>H</th>
        <th>RBI</th>
        <th>BB</th>
        <th>SO</th>
        <th>LOB</th>
        <th>Avg.</th>
      </tr>
      <xsl:apply-templates select="batters/player"/>
    </table>
    <table border="1">
      <tr>
        <th colspan="9">Pitchers</th>
      </tr>
      <tr>
        <th>player</th>
        <th>IP</th>
        <th>H</th>
        <th>R</th>
        <th>ER</th>
        <th>BB</th>
        <th>SO</th>
        <th>HR</th>
        <th>ERA</th>
      </tr>
      <xsl:apply-templates select="pitchers/player"/>
    </table>
  </xsl:template>

  <xsl:template match="batters/player">
    <tr>
      <td>
        <xsl:value-of select="."/>
      </td>
      <xsl:apply-templates select="@ab"/>
      <xsl:apply-templates select="@r"/>
      <xsl:apply-templates select="@h"/>
      <xsl:apply-templates select="@rbi"/>
      <xsl:apply-templates select="@bb"/>
      <xsl:apply-templates select="@so"/>
      <xsl:apply-templates select="@lob"/>
      <xsl:apply-templates select="@avg"/>
    </tr>
  </xsl:template>

  <xsl:template match="pitchers/player">
    <tr>
      <td>
        <xsl:value-of select="."/>
      </td>
      <xsl:apply-templates select="@ip"/>
      <xsl:apply-templates select="@h"/>
      <xsl:apply-templates select="@r"/>
      <xsl:apply-templates select="@er"/>
      <xsl:apply-templates select="@bb"/>
      <xsl:apply-templates select="@so"/>
      <xsl:apply-templates select="@hr"/>
      <xsl:apply-templates select="@era"/>
    </tr>
  </xsl:template>
  
  <!--Note a typical error: if the pitchers/player template item is NOT listed/add in here then the value will show outside the table -->
  <xsl:template match="@ab|@r|@h|@rbi|@bb|@so|@lob|@avg|@ip|@er|@hr|@era">
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

</xsl:stylesheet>
