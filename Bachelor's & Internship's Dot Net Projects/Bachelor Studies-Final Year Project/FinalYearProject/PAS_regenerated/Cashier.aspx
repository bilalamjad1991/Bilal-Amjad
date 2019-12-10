<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cashier.aspx.cs" Inherits="PAS_regenerated.Cashier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Cashier</title>
     

	<link rel="shortcut icon" type="image/x-icon" href="css/images/favicon.ico" />
	<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
	<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="all" />
	
	<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
     
	<!--[if lt IE 9]>
		<script src="js/modernizr.custom.js"></script>
	<![endif]-->
	<script src="js/jquery.flexslider-min.js" type="text/javascript"></script>
	<script src="js/functions.js" type="text/javascript"></script>


   <script type="text/javascript">
       function printing() {
           //            window.print();


           var DocumentContainer = document.getElementById('test');
           var WindowObject = window.open('', 'PrintWindow', 'width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
           WindowObject.document.writeln(DocumentContainer.innerHTML);
           WindowObject.document.close();
           WindowObject.focus();
           WindowObject.print();
           WindowObject.close();

       }
         </script>

        
         <script type="text/javascript">
             function HideLabel() {
                 document.getElementById('<%= lblInvoiceStatus.ClientID %>').style.display = "none";

             }
             setTimeout("HideLabel();", 2000);
    </script>
</head>
<body>
<form id="form1" runat="server">
	<!-- wrapper -->
	<div id="wrapper">
		<!-- header -->
		<header class="header">
			<div class="shell">
				<h1 id="logo"><a href="Index.aspx">Medic-Care</a></h1>
				
				<!-- navigation -->
				<nav id="navigation" style="padding-right:20%" >
					<ul >
						<li class="active">
							<%--<a href="Index.aspx">Home</a>--%>
                            <asp:LinkButton ID="lnkbtnHome" runat="server" onclick="lnkbtnHome_Click">Home</asp:LinkButton>
						</li>
						<li>
							<a href="AttendanceSystem.aspx">Attendance</a>
						
						</li>
                          <li style="font-size: 10px "><asp:LinkButton ID="lnkbtnChangePassword" runat="server" 
              onclick="lnkbtnChangePassword_Click">Change Password</asp:LinkButton></li>
      <li style="font-size: 10px"> <asp:LinkButton ID="lnkbtnSignout" runat="server" 
              onclick="lnkbtnSignout_Click">Signout</asp:LinkButton> </li>
           
                        
						<%--<li>
							<a href="#">Features</a>
							<span>Skins &amp; Schemes</span>
						</li>
						<li>
							<a href="#">Portfolio</a>		
							<span>Take a Look</span>
						</li>
						<li>
							<a href="#">Contacts</a>
							<span>Find Us Now</span>
						</li>--%>
					</ul>
                     <%-- <ul style="float:none; padding-left:40%"  >
                     
                      
          
						
					</ul>--%>
					<div class="cl">&nbsp;</div>
				</nav>
				<!-- end of navigation -->
			</div>
		</header>
		<!-- end of header -->
		
		<!-- slider-holder -->
		<div class="slider-holder">
			<!-- shell -->
			<div class="shell">
				<span class="l"></span>
				<span class="r"></span>
				<span class="t"></span>
				<span class="b"></span>
				<%--<a href="#" class="slider-btn">Explore Our Showcase</a>--%>
				<!-- slider -->
				<div class="slider flexslider">
					<ul class="slides">
						<li>
							<img src="css/images/slide1.png" alt="" />
							<%--<div class="slide-cnt">
								<div class="box-t"></div>
								<div class="box-c">
									<div class="box-cnt">
										<h2>Lorem Ipsum Dolor Sit Amet</h2>
										<p>Donec vehicula odio quis lobortis varius, quam nibh pulvinar eros, sed aliquam orci sem nec ipsum. Nunc sed felis vitae nisl faucibus convallis sit amet eget dolor. Fusce sodales consectetur adipiscing. Nunc nulla mauris, blandit nec dapibus porta, porta tempus lectus. </p>
									</div>
									<div class="cl">&nbsp;</div>
								</div>
								<div class="box-b"></div>
							</div>	--%>
						</li>
						<li>
							<img src="css/images/slide2.jpg" alt="" />
							<%--<div class="slide-cnt">
								<div class="box-t"></div>
								<div class="box-c">
									<div class="box-cnt">
										<h2>Lorem Ipsum Dolor Sit Amet</h2>
										<p>Donec vehicula odio quis lobortis varius, quam nibh pulvinar eros, sed aliquam orci sem nec ipsum. Nunc sed felis vitae nisl faucibus convallis sit amet eget dolor. Fusce sodales consectetur adipiscing. Nunc nulla mauris, blandit nec dapibus porta, porta tempus lectus. </p>
									</div>
									<div class="cl">&nbsp;</div>
								</div>
								<div class="box-b"></div>
							</div>--%>	
						</li>

                        <li>
							<img src="css/images/slide3.jpg" alt="" />
                        </li>

					</ul>
				</div>
				<!-- end of slider -->
			</div>
			<!-- end of shell -->	
		</div>	
		<!-- end of slider-holder -->
		
		<!-- shell -->
		<div class="shell">
			<!-- main -->
			<div class="main">
				<section class="cols">
					<div> <%--class="col"--%>
						<h3>Cashier</h3>
						<p style="color:#F2F2F2">test</p>
                       
                        <asp:Label ID="lblInvoice" runat="server" Text="Enter Invoice Number : " Font-Bold="True" ForeColor="Black"></asp:Label>
        <asp:TextBox ID="txtInvoiceNumber" runat="server" Width="102px"></asp:TextBox>
       
        <asp:Button ID="btnCheck" runat="server" Text="Check Bill" 
            onclick="btnCheck_Click" />
           
        <br />
        <asp:Label ID="lblInvoiceStatus" runat="server" ></asp:Label>
        <br />
        <div id="test">
        <table >
        <tr>
                <td><asp:Label ID="lblInvoicenumber" runat="server" Font-Bold="True" ForeColor="Black" ></asp:Label> 
                </td>
      </tr>
         
         <tr>   
                 <td>
                     <asp:Label ID="lblDate" runat="server" Font-Bold="True" ForeColor="Black" ></asp:Label>
                     </td>
        </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" Font-Bold="True"  
            ShowFooter="True" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle HorizontalAlign="Center" BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
            <RowStyle HorizontalAlign="Center" ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>  
        <br />
     
                 
          <table>
          <tr>
          <td><asp:Label ID="lblNetAmt" runat="server" Text="Grand Total :" Font-Bold="True" 
                        ForeColor="Black" Visible="False"></asp:Label></td>
          <td>
           <asp:TextBox ID="txtNetAmount" runat="server" 
                        Width="99px" ReadOnly="True" Visible="False"></asp:TextBox>
          </td>
          </tr>

          <tr>
          <td>
            <asp:Label ID="lblPaid" runat="server" Text=" Paid Amount : " Font-Bold="True" 
                  ForeColor="Black" Visible="False"></asp:Label>
          </td>
          <td>
           <asp:TextBox ID="txtPaid" runat="server" Width="99px" 
                        ontextchanged="txtPaid_TextChanged" Visible="False" 
                  AutoPostBack="True"></asp:TextBox>
          </td>
          <td>
            <asp:RegularExpressionValidator ID="Regexp_price" runat="server" 
                    ErrorMessage="Invalid entry" 
                    ValidationExpression="^\d+$" ControlToValidate="txtPaid" 
                    CssClass="failureNotification"></asp:RegularExpressionValidator>
          </td>
          </tr>
          <tr>
          <td>
             <asp:Label ID="lblReturned" runat="server" Text="Returned Amount :" 
                  Font-Bold="True" ForeColor="Black" Visible="False"></asp:Label>  
          </td>
          <td>
           <asp:TextBox ID="txtReturned" runat="server" Width="99px" Visible="False" ReadOnly="True" 
                       ></asp:TextBox>
          </td>
          </tr>
          
          
          </table>
               
        </div>
        <br />
       <div>
       <table>

       <tr>
      <td>
      </td>
       <td>
       <asp:Button ID="btnPrint" runat="server" Text="Print Receipt" 
            onclick="btnPrint_Click" Visible="False" /> 
       </td>
      <td><asp:Button ID="btnClearBill" runat="server" Text="Clear Bill" 
                  onclick="btnClearBill_Click" Visible="False" /></td>
       </tr>

       </table>
       </div>
						
					</div>

					
					
					<div class="cl">&nbsp;</div>
				</section>
			</div>
			<!-- end of main -->
		</div>
		<!-- end of shell -->
		<div id="footer-push"></div>
	</div>
	<!-- wrapper -->

	<!-- footer -->
	<div id="footer">
		<div class="shell">
			<!-- footer-cols -->
			<section class="footer-cols">
				<div> <%--class="col"--%>
					<h3>MORE <strong>ABOUT US</strong></h3>
					<p>When you come to Medic-Care Pharmacy, you'll be able to count on dependable care from knowledgeable pharmacists and a kind and dedicated support staff. We are wellness specialists committed to your total health, carrying a full line of vitamins and supplements to specialty bandages and first aid products. Our mission is to empower people to make educated health choices while providing prompt, friendly service with quality products. If you do not see what you are looking for, just ask us, we will go out of our way to find it for you.</p>
				</div>
				<%--<div class="col">
					<h3>KEEP <strong>IN TOUCH</strong></h3>
					<p>Cum sociis natoque penatibus et magnis dolor</p>
					<form method="post">
						<input type="text" class="field" value="Your Email Here" title="Your Email Here" />
						<input type="submit" class="submit-btn" value="Submit" />
					</form>
				</div>
				<div class="col contact">
					<h3>CONTACT <strong>US</strong></h3>
					<h4>+ 123 456 78910</h4>
					<a href="#">johndoe@websitename.com</a>
				</div>--%>
				<div class="cl">&nbsp;</div>
			</section>
			<!-- end of footer-cols -->
			<p class="copy">&copy;  Designed by Pioneers </p>
			<div class="cl">&nbsp;</div>
		</div>	
	</div>
	<!-- end of footer -->
    </form>
</body>
</html>







<%--<%--<%--<body>
    <form id="form2" runat="server">
    <div id="Div1">
  <div id="Div2">
    <ul>
   <%--   <li><a href="#" id="topmenu1" accesskey="1">Home</a></li>
      <li><a href="#" accesskey="2">About us</a></li>
      <li><a href="#" accesskey="3">Signout</a></li>--%>
     <%-- <li><asp:LinkButton ID="LinkButton1" runat="server" 
              onclick="lnkbtnChangePassword_Click">Change Password</asp:LinkButton></li>
      <li> <asp:LinkButton ID="LinkButton2" runat="server" 
              onclick="lnkbtnSignout_Click">Signout</asp:LinkButton> </li>
    </ul>
  </div>--%>
  