<?xml version="1.0"?>

<!-- File Name: XslDemo04.xsl -->

<xsl:stylesheet xmlns:xsl="http://www.w3.org/TR/WD-xsl">
   <xsl:template match="/">
      <H2>Book Inventory</H2>
      <xsl:for-each 
         select="INVENTORY/BOOK[BINDING='trade paperback']" 
         order-by="+AUTHOR/LASTNAME; +AUTHOR/FIRSTNAME">
         <SPAN STYLE="font-style:italic">Author: </SPAN>
         <xsl:value-of select="AUTHOR"/><BR />
         <SPAN STYLE="font-style:italic">Title: </SPAN>
         <xsl:value-of select="TITLE"/><BR />
         <SPAN STYLE="font-style:italic">Binding type: </SPAN>
         <xsl:value-of select="BINDING"/><BR />
         <SPAN STYLE="font-style:italic">Number of pages: </SPAN>
         <xsl:value-of select="PAGES"/><BR />
         <SPAN STYLE="font-style:italic">Price: </SPAN>
         <xsl:value-of select="PRICE"/><P />
      </xsl:for-each>
   </xsl:template>
</xsl:stylesheet>
