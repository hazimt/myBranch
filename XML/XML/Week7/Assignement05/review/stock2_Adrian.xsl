<?xml version="1.0" encoding="UTF-8" ?>
<!--
   New Perspectives on XML
   Tutorial 6
   Review Assignment

   Hardin Financial XSL Style Sheet
   Author: Adrian Balasa
   Date:  06/02/2012 

   Filename:         stock2.xsl
   Supporting Files: down.gif, same.gif, stock2.css, up.gif

-->
<xsl:stylesheet  version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" version="4.0"/>
    <!-- declares for browser what kind of file-->
    <xsl:template match="/">
        <html>
            <head>
                <link href="stock2.css" rel="stylesheet" type="text/css"/>   
            </head>
            <body>
                <div id="datetime">
                    <xsl:value-of select="portfolio/date"/> at
                    <xsl:value-of select="portfolio/time"/> 
                </div>
                
                <h1>Current stock values</h1>
                <table border="1" align="center" id="stocktable">
                    <tr>
                        <th>Stock</th>
                        <th>Current</th>
                        <th>Open</th>
                        <th>High</th>
                        <th>Low</th>
                        <th>Volume</th>
                    </tr>
                    <xsl:apply-templates select="portfolio/stock/today">
                    <xsl:sort select="sName/@symbol"/>
                        </xsl:apply-templates>
                  </table>
                
                <h2 id="summary">Summary Information</h2>
                <xsl:apply-templates select="portfolio/stock">
                    <xsl:sort select="sName/@symbol"/>
                </xsl:apply-templates>
                
            </body>
        </html>
        
        
    </xsl:template>
    <xsl:template match="today">
        
            <tr>
                <td class="symbolcell">
                    <xsl:choose>
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
                   
             <a href="#symbol">
                        <xsl:value-of select="../sName/@symbol"/>
                    </a>

                </td>
         
                        <xsl:apply-templates select="@current"/>
                        <xsl:apply-templates select="@open"/>
                        <xsl:apply-templates select="@high"/>
                        <xsl:apply-templates select="@low"/>
                        <xsl:apply-templates select="@vol"/>

            </tr>
       
    </xsl:template>
    <xsl:template match="stock">
        <h3 id="sName/@symbol">
            <xsl:value-of select="sName"/>
        </h3>
        <table border="10" class="summtable">
            <tr>
                <th class="head2">Category</th>
                 <xsl:apply-templates select="category"/>
            </tr>
            <tr>
                <th class="head2">Year High</th>
                <xsl:apply-templates select="year_high"/>
                

            </tr>
            <tr>
                <th class="head2">Year Low</th>
               <xsl:apply-templates select="year_low"/>
              

            </tr>
            <tr>
                <th class="head2">P/E Ratio</th>
               <xsl:apply-templates select="pe_ratio"/>
                

            </tr>
            <tr>
                <th class="head2">Earnings</th>
                 <xsl:apply-templates select="earnings"/>
                

            </tr>
            <tr>
                <th class="head2">Yield</th>
                
                    <xsl:apply-templates select="yield"/>
               
               

            </tr>
        </table>
        <p>
            <xsl:value-of select="description"/>
        </p>
    </xsl:template>
    <xsl:template match="@open|@high|@low|@vol|@current|@date|@close|category|year_high|year_low|pe_ratio|earnings|yield">
        <td>
            <xsl:value-of select="."/>
        </td>
        
    </xsl:template>
</xsl:stylesheet>

