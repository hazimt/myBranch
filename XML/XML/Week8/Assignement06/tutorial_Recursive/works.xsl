<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 7
   Tutorial Case

   Wizard Works XSLT Style Sheet
   Author: 
   Date:   

   Filename:         works.xsl
   Supporting Files: library.xsl, logo.jpg, works.css

-->

<xsl:stylesheet version='1.0' xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:import href="library.xsl"/>
  
  <!--pg406-->
  <xsl:param name="filter" select="''"/>
  
  <!--pg 401-->
  <!--xsl:variable name="group" select="customers/customer"/-->
  <!--predicate-->
  <!-- look at the xml and all CID="B101" that starts with B rather than C and give them a varaible name-->
  <!--now let's restrict the number of customers only to one starting wiht B-->
  <!--xsl:variable name="group" select="customers/customer[starts-with(@CID, 'B')]"/-->
  <xsl:variable name="group" select="customers/customer[starts-with(@CID, $filter)]"/>

  <xsl:output method="html" version="4.0" />

<xsl:template match="/">
   <html>
   <head>
     <!--adding spaces between customer and orders does NOT work.  The browser will remove it-->
     <!--so add &nbsp speical symbol for space.  But &nbsp is an html code.  So it won't work.  So use &#160;-->
      <title>Customer Orders</title>
      <link href="works.css" rel="stylesheet" type="text/css" />
   </head>

   <body>
     <!--This table represent the Summary Information-->
   <table class="summary" border="2" cellpadding="2">
   <tr>
      <th colspan="2" id="summtitle">Summary Information</th>
   </tr>
   <tr>
      <th>Filter</th>
      <td>
        <!--If filter is nothing then put all into the cell-->
        <xsl:if test="$filter=''">all</xsl:if>
        <!--this will just show the actual value of the filter-->
        <xsl:value-of select="$filter"/>
      </td>
   </tr>
   <tr>
      <th>Customers</th>
      <td>
        <!--where customer is an element in the xml-->
        <!--the double slash // means take all the customer elemnets that are present in the document not under any specific xpath. but anywhere-->
        <!--pg385-->
        <!--xsl:value-of select="count(//customer)"/-->
        <xsl:value-of select="count($group)"/>
      </td>
   </tr>
   <tr>
      <th>Orders</th>
      <td>
        <!--where orders is an element in the xml-->
        <!--xsl:value-of select="count(//orders)"/-->
        <xsl:value-of select="count($group//orders)"/>
      </td>
   </tr>
   <tr>
      <th>Items</th>
      <td>
        <!--xsl:value-of select="count(//item)"/-->
        <xsl:value-of select="count($group//item)"/>
      </td>
   </tr>
   <tr>
      <th>Quantity</th>
      <td>
        <!--qty attribute can be counted -->
        <!--so to access an attribute you add the @ sign-->
        <!--xsl:value-of select="sum(//@qty)"/-->
        <xsl:value-of select="sum($group//@qty)"/>
      </td>
   </tr>
   <tr>
      <th>Total</th>
      <td>
        <xsl:call-template name="totalCost">
          <xsl:with-param name="list" select="$group//item"/>
        </xsl:call-template>
      </td>
   </tr>
   </table>
   
   <p><img src="logo.jpg" alt="Wizard Works" /></p>
      <!--pg 396-->
     <!--adding spaces between customer and orders does NOT work.  The browser will remove it-->
     <!--so add &nbsp speical symbol for space.  But &nbsp is an html code.  So it won't work.  So use &#160;-->
     <h1>Customer &#160;&#160;&#160;&#160; Orders</h1>
     <!--xsl:apply-templates select="customers/customer" /-->
     <xsl:apply-templates select="$group" />
   </body>
   </html>
</xsl:template>


<xsl:template match="customer">
    <table class="custinfo" border="3" cellpadding="2">
    <tr>
       <th>Customer</th>
       <td><xsl:value-of select="cName/lName" />
           <xsl:if test="cName/fName !=''">, </xsl:if>
           <xsl:value-of select="cName/fName" />
       </td>
    </tr>
    <tr>
       <th>Customer ID</th>
       <td><xsl:value-of select="@CID" /></td>
    </tr>
    <tr>
       <th>Address</th>
       <td><xsl:value-of select="street" /><br />
           <xsl:value-of select="city" />, 
           <!--add spaces between city and state-->
           <xsl:value-of select="state" />&#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="postalCode" />
       </td>
    </tr>
    <tr>
       <th>Phone Number</th>
       <td><xsl:value-of select="phone" /></td>
    </tr>  
    </table>

    <xsl:apply-templates select="orders" />
</xsl:template>


<xsl:template match="orders">
   <table class="orderinfo" border="10" cellpadding="2">
   <tr>
      <th>Date</th>
      <th>Item</th>
      <th>Description</th>
      <th>Qty</th>
      <th>Price</th>
      <th>Total</th>
   </tr>

   <xsl:apply-templates select="order/items" />

   <tr>
      <th class="grand" colspan="3">Grand Total</th>
      <td class="grand">
        <!---->
        <xsl:value-of select="sum(order/items/item/@qty)"/>
        <!--now Grand Total	19 shows -->
      </td>
      <td class="grand"></td>
      <td class="grand">
        <xsl:call-template name="totalCost">
          <xsl:with-param name="list" select="order/items/item"/>
        </xsl:call-template>
      </td>
   </tr>

   </table>
</xsl:template>


<xsl:template match="items">
   <xsl:apply-templates select="item" />

   <tr>
      <th class="sub" colspan="3">Subtotal</th>     
      <td class="sub">
        <!--sum only qty that belong to item-->
        <!--we have an element called item, which has an attribute called qty. And we want to add those.  And only those that belong to the items element-->
        <!--so before we calculated all the values of qty across the entire xml doc.  Here it's just the items node for each item-->
        <xsl:value-of select="sum(item/@qty)"/>
        <!--now Subtotal	7 and Subtotal	12 are showing-->
      </td>
      <td class="sub"></td>
      <td class="sub">
        <xsl:call-template name="totalCost">
          <xsl:with-param name="list" select="item"/>
        </xsl:call-template>
      </td>
   </tr>
</xsl:template>


<xsl:template match="item">
   <tr>
     <!-- We want to merge the following list of rows
      Date	Item	Description	Qty	Price	Total
      6/16/2008	(1)	Long Sparklers (box 20)	1	19.95	
      6/16/2008	(2)	Goblin Fountain	2	29.95	
      6/16/2008	(3)	Dragon Fountain	2	25.50	
      6/16/2008	(4)	Nighteyes (box 10)	1	29.95	
      6/16/2008	(5)	Assorted items Box #1	1	19.95

      This is how it works
      order .... itesms   .... item
                          .... item
    -->
     <xsl:if test="position()=1">
       <!--This can also be done like the statement below it-->
       <!--td class="tdtext" rowspan="{count(../../items/item)}"-->
       <td class="tdtext" rowspan="{count(../item)}"> <!--this measn you are at item.  Go up from there one up. i.e now you are at items-->
           <xsl:value-of select="../../@date" />
       </td>
     </xsl:if>
     
      <td class="tdtext">
        <!--item elements is a group of them.  -->
        <!-- Each one of those items is going to get a number/ordering number-->
        <!--With this line the Item column is numbered-->
        <xsl:number value="position()" format="(1)"/>
        <!--note the one stands for any number-->
      </td>
      <td class="tdtext"><xsl:value-of select="." /></td>
      <td><xsl:value-of select="@qty" /></td>
      <td><xsl:value-of select="@price" /></td>
      <td>
        <!--populate Total column-->
        <!--xsl:value-of select="@qty * @price"/-->
        <!-- to divide use div not backslash-->
        <!--xsl:value-of select="@qty div @price"/-->
        <!-- To formate the number do this-->
        <!-- menas .5  becomes 0.5  if it's 1 it will be 1.00-->
        <xsl:value-of select="format-number(@qty * @price, '#,##0.00')"/>
        <!--every 0 means force or make sure there is a zero.  # means it's optional to have a digit there-->
        <!--xsl:value-of select="format-number(@qty * @price, '#,000.00')"/-->
        
      </td>
   </tr>
</xsl:template>

</xsl:stylesheet>