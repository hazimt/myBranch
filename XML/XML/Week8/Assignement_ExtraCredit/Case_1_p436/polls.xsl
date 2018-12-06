<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 7
   Case Problem 1

   Election Results XSLT Style Sheet
   Author: 
   Date:   

   Filename:         polls.xsl
   Supporting Files: back.jpg, logo.jpg
-->


<xsl:stylesheet version='1.0' xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" version="4.0" />

  <!--Step 3-->
  <!--<td class="red"> </td>-->

  <!--Create two a global variable-->
  <xsl:variable name="redcell">
    <td class="red"> </td>
  </xsl:variable>
  <xsl:variable name="bluecell">
    <td class="blue"> </td>
  </xsl:variable>
  <xsl:variable name="greencell">
    <td class="green"> </td>
  </xsl:variable>


  <xsl:template match="/">
   <html>
   <head>
      <title>Election Night Results</title>
      <link href="polls.css" rel="stylesheet" type="text/css" />
   </head>
   <body>
      <div id="intro">
         <p><img src="logo.jpg" alt="Election Day Results" /></p>
         <a href="#">Election Home Page</a>
         <a href="#">President</a>
         <a href="#">Senate Races</a>
         <a href="#">Congressional Races</a>
         <a href="#">State Senate</a>
         <a href="#">State House</a>
         <a href="#">Local Races</a>
         <a href="#">Judicial</a>
         <a href="#">Referendums</a>
      </div>

      <div id="results">
         <h1>Congressional Races</h1>
         <xsl:apply-templates select="polls/race" />
      </div>
   </body>
   </html>
</xsl:template>

<xsl:template match="race">
   <h2><xsl:value-of select="title" /></h2>
   <table cellpadding="1" cellspacing="1">
      <tr><th>Candidate</th><th class="num">Votes</th></tr>
      <xsl:apply-templates select="candidate" />
   </table>
</xsl:template>

<xsl:template match="candidate">
  <!-- Step 4 -->
  <!--Create a local variable that is equal to the votes divided by the sum of the total votes of the candidates-->
  <xsl:variable name="percent" select="votes div sum(..//votes)"/>    
   <tr>
      <td class="name">
          <xsl:value-of select="name" /> 
          (<xsl:value-of select="party" />)
      </td>
     <!--Second table Cell-->
      <td class="num">
        <!--Step 5-->
        <!--Format the value of the votes element-->
        <!--    <xsl:value-of select="votes" />   -->
        <xsl:value-of select="format-number(votes, '#,##0')"/>
        <!--Step 6-->
        <!--Display the value of the precent variable, formated as #0%-->
        <!--(<xsl:value-of select="$percent"/>)-->
        (<xsl:value-of select="format-number($percent,'#0%')"/>)
      </td>
   </tr>
</xsl:template>
  
  <!--
  <xsl:template name="showBar">
    <xsl:param name="cells" select="0" />
    <xsl:param name="partyType" />

    <xsl:if test="$cells > 0" >
      <xsl:choose>
        <xsl:when test="$partyType='R'">
          <xsl:copy-of select="$redcell" />
        </xsl:when>
        <xsl:when test="$partyType='D'">
          <xsl:copy-of select="$bluecell" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:copy-of select="$greencell" />
        </xsl:otherwise>
      </xsl:choose>

      <xsl:call-template name="showBar">
        <xsl:with-param name="cells" select="$cells - 1" />
        <xsl:with-param name="partyType" select="$partyType" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>-->
  
  
</xsl:stylesheet>