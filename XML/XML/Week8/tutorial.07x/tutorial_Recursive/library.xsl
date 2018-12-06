<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 7
   Tutorial Case

   Wizard Works Style Sheet Library
   Author: Hazim Mohaisen
   Date:   06/05/2002

   Filename:         library.xsl
   Supporting Files: 

-->

<xsl:stylesheet version='1.0' xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!--Page 413-->
  <xsl:template name="totalCost">
    <xsl:param name="list"/>
    <xsl:param name="total" select="0"/>

    <!--Page 421-->
    <!--Calculate the total item cost-->
    <xsl:choose>
      <xsl:when test="$list">
        <!--pg 422-->
        <!--Calculate the first item cost-->
        <xsl:variable name="first" select="$list[1]/@qty * $list[1]/@price"/>

        <!--Call the total cost template-->
        <xsl:call-template name="totalCost">
          <xsl:with-param name="list" select="$list[position()>1]"/>
          <xsl:with-param name="total" select="$first + $total"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <!--Display the total cost-->
        <xsl:value-of select="format-number($total, '$#,#00.00')"/>
      </xsl:otherwise>
    </xsl:choose>

  </xsl:template>

</xsl:stylesheet>