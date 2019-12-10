<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PAS_regenerated.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Medic Care</title>
	<link rel="shortcut icon" type="image/x-icon" href="css/images/favicon.ico" />
	<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
	<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="all" />
	
	<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
	<!--[if lt IE 9]>
		<script src="js/modernizr.custom.js"></script>
	<![endif]-->
	<script src="js/jquery.flexslider-min.js" type="text/javascript"></script>
	<script src="js/functions.js" type="text/javascript"></script>
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
				<nav id="navigation"  style="padding-right:30%">
					<ul>
						<li class="active">
							<a href="#">Home</a>
						
						</li>
						<li>
							<a href="AttendanceSystem.aspx">Attendance</a>
							
						</li>
                        <li style="font-size: 10px ">
								<a href="forgotPassword.aspx" >Forgot Password</a>
							
						</li>
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
						<h3>User Account</h3>
						<p style="color:#F2F2F2">test</p>
                        <table>
                        <tr>
                        <td>
                        <asp:Label ID="lblUsername" runat="server" Text="UserName:" Font-Size="Medium"></asp:Label></td>
                        <td>
                        <asp:TextBox ID="txtusername"  runat="server" ToolTip="Enter username" 
                                        Height="27px" Width="153px"></asp:TextBox>
                        </td>

                        <td>
                       &nbsp;&nbsp; 
                       </td>

                       <td>
                       <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Size="Medium"></asp:Label>
                       </td>

                       <td>
                       <asp:TextBox ID="txtuser_password" runat="server" TextMode="Password" 
                       ToolTip="Enter your Password" Height="27px" Width="153px"></asp:TextBox>
                       </td>

                       <td>
                       <asp:DropDownList ID="user_selection" runat="server" Height="27px" 
                                        Width="121px">
                                <asp:ListItem Text="---Select User---" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Administrator" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Pharmacist" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cashier" Value="3"></asp:ListItem> 
                                </asp:DropDownList>        
                       </td>
                       <td>
                       
                       
                       <asp:Button ID="Button1" runat="server" Text="Signin" 
                                 Height="27px" Width="65px" onclick="Button1_Click"></asp:Button>
                       
                       </td>
                      
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="Username is Required"></asp:RequiredFieldValidator>
                                
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>  </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtuser_password" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
                                
                            </td>
                        <td>
                            <asp:Label ID="show_msg" runat="server"></asp:Label>
                        </td>
                        <td>  </td>
                        </tr>
                        </table>
						
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
