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
        <xsl:apply-templates select="boxscore/team"/>
        <xsl:apply-templates select="boxscore/name/team"/>

      </body>
    </html>
  </xsl:template>

  <xsl:template match="team">
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
      <tr>
        <th colspan="6">Batters</th>
      </tr>
      <tr>
        <th>Day</th>
        <th>Open</th>
        <th>High</th>
        <th>Low</th>
        <th>Close</th>
        <th>Volume</th>
      </tr>
    </table>
  </xsl:template>


</xsl:stylesheet>
