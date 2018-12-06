<?xml version="1.0"?>

<!-- File Name: XslDemo06.xsl -->

<xsl:stylesheet xmlns:xsl="http://www.w3.org/TR/WD-xsl">
   <xsl:template match="/">
      <H2>Books In Stock</H2>
      <TABLE BORDER="1" CELLPADDING="5">
         <THEAD>
            <TH>Title</TH>
            <TH>Author</TH>
            <TH>Binding Type</TH>
            <TH>Number of Pages</TH>
            <TH>Price</TH>
         </THEAD>
         <xsl:for-each select="INVENTORY/BOOK[@InStock='yes']">
            <TR ALIGN="CENTER">
               <TD>
                  <xsl:value-of select="TITLE"/>
               </TD>
               <TD>
                  <xsl:value-of select="AUTHOR"/> <BR/>
                  (born <xsl:value-of select="AUTHOR/@Born"/>)
               </TD>
               <TD>
                  <xsl:value-of select="BINDING"/>
               </TD>
               <TD>
                  <xsl:value-of select="PAGES"/>
               </TD>
               <TD>
                  <xsl:value-of select="PRICE"/>
               </TD>
            </TR>
         </xsl:for-each>
      </TABLE>
   </xsl:template>
</xsl:stylesheet>
