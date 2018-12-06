<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Tutorial Case

   Hardin Financial XSL Style Sheet
   Author: Hazim Mohaisen
   Date:   06/02/2012

   Filename:         stock.xsl
   Supporting Files: down.gif, same.gif, stock.css, up.gif

-->
<!-- pg305 -->



<!--Can use xsl:Transform instead of xsl:stylesheet  below"-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!--Declares for the browser what kind of output whether it's an xml at the end or an html document.  This will be an html document of verion 4.0-->
  <!-- Specify the output format of the result document pg 314 -->
  <!--Here we are saying the output document should be formatted as an html version 1 -->
  <xsl:output method="html" version="1.0"/>

  
  <!--What the template to. i.e it applies to the whole xml document to the whole portfolio document -->
  <!--Create a root template use the "/" -->
  <xsl:template match="/">
    <!--populate the root tempalte: means add html, head, title, link, body ...etc. -->
    <!--So this is just to formate the output to make it look nice using the css style sheet-->
    <html>
      <head>
        <!--these are called Literal result elements pg 311, 312-->
        <title>Stock Information</title>
        <link href="stock.css" rel="stylesheet" type="text/css" />
      </head>
      <body>
        <!-- div generic block level.  It creates a block-->
        <!--display the value of the date and time element or display the date and time node -->
        <div id="datetime">
          <!-- b for bold-->
          <b>Last Updated: </b>
          <!-- Page 299 chart/table-->
          <!-- Retrieve two pieces of info date and time given a path to the node-->
          <!--one piece of xpath-->
          <!--insert a nodes value into the result document, where portfolio/date is an Xpath that identifies the nodde from the soruce documen's node tree-->
          <xsl:value-of select="portfolio/date"/> at
          <!--this is a relative not absolute path.  Because match above defined that we are at the root-->
          <!--Note portfolio can be moved to the top instead of being left here and then we will have just time and date above instead of portfolio\date, portfolio\time-->
          <xsl:value-of select="portfolio/time"/>
        </div>
        <h1>Hardin Financial</h1>
        <h1>Stock Information</h1>

        <!-- Since in the xml doc there are many stock elements we want to scan reach all of them we do it this way-->
        <!-- Keep going through the nodes of the tree -->
        <!-- Display multiple stock names -->
        <!-- To apply a style to each occurence of a node use for-each select-->
        <!--This is a loop -->
        <!-- <xsl:for-each select ="portfolio/stock">
          <h3>
            <xsl:value-of select="sName"/>
          </h3>
        </xsl:for-each>
        -->
        <!-- replace the above with this and the code below-->

        <!--pg 346-->
        <!--Predicates: query the DB and select something specific-->
        <!--category: Industrial stocks -->
        <h2 class="category">Industrials</h2>
        <!--apply a template using the xpath expression matching a node set in the source document -->
        <!--choose only those stocks that belong to category industrials-->
        <xsl:apply-templates select="portfolio/stock[category='Industrials']">
          <xsl:sort select="sName"/>
        </xsl:apply-templates>

        <!--category: Utility stocks -->
        <h2 class="category">Utilities</h2>
        <xsl:apply-templates select="portfolio/stock[category='Utilities']">
          <xsl:sort select="sName"/>
        </xsl:apply-templates>

        <!--category: Transportation stocks -->
        <h2 class="category">Transportation</h2>
        <xsl:apply-templates select="portfolio/stock[category='Transportation']">
          <xsl:sort select="sName"/>
        </xsl:apply-templates>
      </body>
    </html>
  </xsl:template>
  
  <!--Use a different approach other than for-each to retrive nodes -->
  <!-- Because of this we commented the for-each code above-->

  <!--Consider them a fun it retireves from the sName & description-->
  <xsl:template match="stock">
    <div>
      <!--Page 325-->
      <!--this is a function name below called match=sName -->
      <xsl:apply-templates select="sName"/>
      <!-- add this after adding template match today below
      -->
      <!-- Create current stock values table pg 326-->
      <xsl:apply-templates select="today"/>
      <p>
        <!--retrivew not just name but also description-->
        <xsl:value-of select="description"/>
      </p>
      <!-- pg 330 apply the below method called five_day -->
      <xsl:apply-templates select="five_day"/>
    </div>
  </xsl:template>

  <!-- This is the function (think of it) being called above-->
  <xsl:template match="sName">
    <h3>
      <!--applyl to Aluminum Company of America (AA) -->
      <!--so we need this guy       http://www.alcoa.com.  But here we are at the sName so we need to go up to stock and then go down to link tag  -->
      <!--This is a trick to connect html with xml pg 335-->
      <!-- Inert links in the result document.  Note link is an element -->
      <!-- stock name and symbol appears as a link -->
      <a href="{../link}">
        <xsl:value-of select="."/>
        <!--to retrive attributes specically the symbol attribute pg325-->
        <!-- the brackets show around AA, UCL, GM etc ...-->
        <!--Display symbol attribute value of the sName element pg 325-->
        (<xsl:value-of select="@symbol"/>)
      </a>
    </h3>    
  </xsl:template>


  <!--it's an empty element no values but it has attributes pg326-->
  <!--This is a function that apply to one element-->
  <!-- Create current stock values table -->
  <!--Template for the today element -->
  <xsl:template match="today">
    <table>
      <!--table row - that is creating a whole row-->
      <!--this is the first row now has been created-->
      <tr>
        <!-- th is an html table heading first row names/values-->
        <th>Current</th>
        <th>Open</th>
        <th>High</th>
        <th>Low</th>
        <th>Volume</th>
      </tr>
      <tr>
        <!--This or the commented section below-->
        <!--But this is more efficient-->
        <!--
        <td>
          <xsl:apply-templates select="@current"/>
        </td>
        <td>
          <xsl:apply-templates select="@open"/>
        </td>
        <td>
          <xsl:apply-templates select="@open"/>
        </td>
        <td>
          <xsl:apply-templates select="@high"/>
        </td>
        <td>
          <xsl:apply-templates select="@low"/>
        </td>
        <td>
          <xsl:apply-templates select="@vol"/>
        </td>
        ..etc
        -->
        <!--this calls the function it's important to create the function i.e template for you to call it.  And the element or in this case attribute is being specifically targeted/called/applied to -->
        <!-- let's add a new cell -->
        <!--<xsl:apply-templates select="@current"/>-->
        <td>
          <!--pg 341-pg 343-->
          <!-- Applying a conditional Node -->
          <!--Conditional sytle created for the @current attribute -->
          <xsl:choose>
            <!--replace with the gif of an arrow if data/stock is going down-->
            <xsl:when test="@current &lt; @open">
              <img src="down.gif"/>
            </xsl:when>
            <xsl:when test="@current > @open">
                <img src="up.gif"/>
              </xsl:when>
              <xsl:otherwise>
                <img src="same.gif"/>
              </xsl:otherwise>
          </xsl:choose>
        </td>
        <!-- let's end a new cell -->
        <xsl:apply-templates select="@open"/>
        <xsl:apply-templates select="@high"/>
        <xsl:apply-templates select="@low"/>
        <xsl:apply-templates select="@vol"/>
      </tr>
    </table>
  </xsl:template>

  <!--this is the second row now has been created-->
  <!-- now let's deal with this <day open="31.20" high="32.61" low="30.15" close="30.51" vol="6.70" date="11/17/2008">1</day> -->
  <!--Create a row in one/another table-->
  <!-- callit item123-->
  <!--This is a function that apply to one element-->
  <!--Create and apply the day template pg 331-->
  <xsl:template match="day">
    <!--let's create a row -->
    <!--So create a table-->
    <tr>
      <xsl:apply-templates select="@date"/>
      <xsl:apply-templates select="@open"/>
      <xsl:apply-templates select="@high"/>
      <xsl:apply-templates select="@low"/>
      <xsl:apply-templates select="@close"/>
      <xsl:apply-templates select="@vol"/>
    </tr>
  </xsl:template>
  <!--This is a function that apply to many elements pg 327-->
  <!--Template stock value attributes -->
  <!--Removed @current attribute from the match list because it now has it's own conditional statement/style-->
  <xsl:template match="@current|@open|@high|@low|@vol|@date|@close">
    <!--This td creates one cell but we need to add more-->
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

  <!-- pg 329, pg 330  working with attribute nodes -->
  <!--Create the five_day stock table -->
  <xsl:template match="five_day">
    <table>
      <tr>
        <th colspan="6">Recent History</th>
      </tr>
      <tr>
        <th>Day</th>
        <th>Open</th>
        <th>High</th>
        <th>Low</th>
        <th>Closed</th>
        <th>Volume</th>
      </tr>
      <!-- apply callit item123 here-->
      <!--this seems applied once.  But it's actually it's being applied many times i.e in this case 5 times the number of times it's showing in the xml document -->
      <!--Create and apply the day template pg 331 -->
      <!--Applies the day template sorted by the descending value of the day element -->
      <xsl:apply-templates select="day">
        <!--pg 338 sorting a node set-->
        <!-- Sort the rows in the five-day table -->
        <xsl:sort data-type="number" order="descending"/>
      </xsl:apply-templates>

    </table>
  </xsl:template>
  <!--This is how you create a comment in the resulting document -->


</xsl:stylesheet>

<!-- Relational DB to SQL 
is like
  XML to XSLT
  
  i.e XSLT query and diplay the results of the XML
-->
