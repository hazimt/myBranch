<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 7
   Review Assignment

   Wizard Works XSLT Style Sheet
   Author: Hazim Mohaisen
   Date:   06/16/2012

   Filename:         items.xsl
   Supporting Files: items.css, logo.jpg, shared.xsl

-->

<xsl:stylesheet version='1.0' xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!--To use the totalRevenue tempalte that exist in the shared.xsl template need to import it here.-->
  <xsl:import href="shared.xsl"/>
  
  <xsl:output method="html" version="4.0" />

  <!--Global paramter called filter set default value to an empty string-->
  <xsl:param name="filter" select="''"/>
  <!--Global paramter called filter set default value to the node set of all of the group elements in the source document whose type attribute starts with the value of the filter paramter-->
  <xsl:variable name="productList" select="catalog/group[starts-with(@type, $filter)]"/>

  <!--root template-->  
  <xsl:template match="/">
   <html>
   <head><title>Wizard Works Products</title></head>
   <link href="items.css" rel="stylesheet" type="text/css" />
   <body>

   <table class="Summary" border="2" cellpadding="2">
   <tr>
      <!--Table header like filter, products, quantity, revenue ...etc-->
      <th colspan="2">Summary Information</th>
   </tr>
     <!--table row = is the row in the table-->
     <tr>
      <th class="Summary">Filter</th>
     <!--table data = is the cell-->
     <td class="Summary">
       <!--If filter is nothing then put all into the cell-->
       <xsl:if test="$filter=''">all</xsl:if>
       <!--this will just show the actual value of the filter-->
       <xsl:value-of select="$filter"/>
     </td>
   </tr>
   <tr>
      <th class="Summary">Products</th>
      <td class="Summary">
        <!--where orders is an element in the xml-->
        <!--xsl:value-of select="count(//orders)"/-->
        <!--Display the count of product elements within the node set referenced by the productList variable-->
        <xsl:value-of select="count($productList//product)"/>
      </td>
   </tr>
   <tr>
      <th class="Summary">Quantity</th>
     <td class="Summary">
       <!--qty attribute can be counted -->
       <!--so to access an attribute you add the @ sign-->
       <!--xsl:value-of select="sum(//@qty)"/-->
       <!--Display the sum of product quantities ordered within the node set referenced by the productList variable-->
       <xsl:value-of select="sum($productList//@qty)"/>
     </td>
   </tr>
   <tr>
      <th class="Summary">Revenue</th>
      <td class="Summary">
        <xsl:call-template name="totalRevenue">
          <xsl:with-param name="list" select="$productList//order"/>
        </xsl:call-template>
      </td>
   </tr>
   </table>
   
   <p><img src="logo.jpg" alt="Wizard Works" /></p>

   <!-- In select="catalog/group" the catalog/group is the select attribute -->  
   <!--Change the select attribute of the apply-template element so that it selects the node set referenced by the productList variable-->
   <!--<xsl:apply-templates select="catalog/group" />-->
     <xsl:apply-templates select="$productList" />
   </body>
   </html>
</xsl:template>


<xsl:template match="group">
   <h1><xsl:value-of select="@type" /></h1>
   <table class="prod" border="10" cellpadding="5" bordercolor="blue" bordercolorlight="lightblue">
   <tr>
      <th>Name</th>
      <th>Order ID</th>
      <th>Date</th>
      <th>Qty</th>
      <th>Price</th>
      <th>Total</th>
   </tr>
   <xsl:apply-templates select="product">
      <xsl:sort select="pName" />
   </xsl:apply-templates>
   <tr>
      <th colspan="3" class="num">Total</th>
      <th class="num">
        <!---->
        <!--Second Cell, of the last table row, display the sum of the product quantity of the items ordered in the product/order node set-->
        <xsl:value-of select="sum(product/order/@qty)"/>
      </th>
      <th colspan="2" class="num">
        <xsl:call-template name="totalRevenue">
          <xsl:with-param name="list" select="product/order"/>
        </xsl:call-template>
      </th>
   </tr>
   </table>
</xsl:template>

<xsl:template match="product">
   <xsl:apply-templates select="order">
      <xsl:sort select="@OID" />
   </xsl:apply-templates>
</xsl:template>

<xsl:template match="order">
<tr>
  <xsl:if test="position()=1">
    <!--This can also be done like the statement below it-->
    <!--td class="tdtext" rowspan="{count(../../items/item)}"-->

    <!--This can also be done like the statement below it-->
    <!--td class="tdtext" rowspan="{count(../../items/item)}"-->
    <!--td class="tdtext" rowspan="{count(../item)}"--> <!--this measn you are at item.  Go up from there one up. i.e now you are at items-->

    <!--<td rowspan="orders">-->
    <td rowspan="{count(../order)}">
      <!-- Product name -->
      <!--this measn you are at item.  Go up from there one up. i.e now you are at items-->
      <xsl:value-of select="../../pName" />
    </td>
  </xsl:if>

  <td><xsl:value-of select="../pName" /></td>
   <td><xsl:value-of select="@OID" /></td>
   <td><xsl:value-of select="@date" /></td>
   <td class="num"><xsl:value-of select="@qty" /></td>
   <td class="num"><xsl:value-of select="@price" /></td>
   <td class="num">
     <xsl:value-of select="format-number(@qty * @price, '#,##0.00')"/>
   </td>
</tr>
</xsl:template>


</xsl:stylesheet>