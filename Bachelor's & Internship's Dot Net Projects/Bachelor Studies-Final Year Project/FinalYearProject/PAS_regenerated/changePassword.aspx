<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="PAS_regenerated.changePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Change Password</title>
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
				<nav id="navigation" style="padding-right:1%">
					<ul>
						<li class="active">
							<%--<a href="Index.aspx">Home</a>--%>
                             <asp:LinkButton ID="lnkbtnHome" runat="server" onclick="lnkbtnHome_Click">Home</asp:LinkButton>
						<%--	<span>Get Started</span>--%>
						</li>
						<li>
							<a href="searchConsole.aspx">Search Medicine</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                        <li>
							<a href="Bill.aspx">Billing</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                        <li>
							<a href="AttendanceSystem.aspx">Attendance</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                         <li><asp:LinkButton ID="lnkbtnRegister" runat="server" Visible="True" 
            onclick="lnkbtnRegister_Click" Enabled="False">Register</asp:LinkButton></li>
            </ul>
           
            <ul style="padding-left:83%">
           
        

      <li style="font-size: 10px"> <asp:LinkButton ID="lnkbtnSignout" runat="server" 
              onclick="lnkbtnSignout_Click">Signout </asp:LinkButton>  </li>
			<%--	<li style="font-size: 10px">
                <a> <asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label></a>
                </li>	--%>	    
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
						<h3>Change Password</h3>
						<p style="color:#F2F2F2">test</p>
                       
                         <table>
               <%--<tr>
                    <td class="label"> <asp:Label Height="25px" Width="100px" ID="username" 
                            runat="server" Text="User Name" Font-Bold="True" Font-Size="Medium"></asp:Label> </td>
               </tr>
               <tr>     
                    <td> <asp:TextBox ID="txtusername" runat="server" ToolTip="Enter User Name" 
                            Height="32px" Width="208px"
                            ></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="username_required" runat="server" ControlToValidate="txtusername" 
                        CssClass="failureNotification" ErrorMessage="UserName is Required">*</asp:RequiredFieldValidator>
                    </td>
               </tr>--%>
               <tr>
                    <td class="label"> <asp:Label Height="25px" Width="115px" ID="password" 
                            runat="server" Text="Old Password" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Black" ></asp:Label></td>
                </tr>
                <tr>
                    <td> 
                        <asp:TextBox ID="txtuser_oldpassword" runat="server" ToolTip="Enter old Password" TextMode="password" 
                            Height="32px" Width="208px"></asp:TextBox></td>
<%--                    <td>
                        <asp:RequiredFieldValidator ID="password_required" runat="server" ControlToValidate="txtuser_oldpassword"
                        CssClass="failureNotification" ErrorMessage="Password is Required">*</asp:RequiredFieldValidator>
                    </td>--%>
               </tr>
               <tr>
                    <td class="label">
                         <asp:Label Height="25px" Width="145px" ID="Label2" runat="server" 
                             Text="New Password" Font-Bold="True" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox ID="txtuser_newpassword" runat="server" ToolTip="Enter New Password" TextMode="password" 
                            Height="32px" Width="208px"></asp:TextBox>
                    </td>
<%--                    <td>
                        <asp:RequiredFieldValidator ID="newpassword_required" runat="server" ControlToValidate="txtuser_newpassword"
                        CssClass="failureNotification" ErrorMessage="New Password is Required">*</asp:RequiredFieldValidator>
                    </td>--%>
               </tr>
               <tr>
                    <td class="label">
                         <asp:Label Height="25px" Width="145px" ID="Label1" runat="server" 
                             Text="Confirm Password" Font-Bold="True" Font-Size="Medium" 
                             ForeColor="Black" ></asp:Label>
                    </td>
               </tr>
               <tr>
                    <td>
                       <asp:TextBox ID="txtuser_cnfrmpassword" runat="server" ToolTip="Confirm Password" TextMode="password" 
                            Height="32px" Width="208px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator ID="cmpValidate" runat="server"  
                            ErrorMessage="Confirm password must match!" 
                            ControlToCompare="txtuser_newpassword" 
                            ControlToValidate="txtuser_cnfrmpassword" CssClass="failureNotification"></asp:CompareValidator>
                    </td>
<%--                     <td>
                        <asp:RequiredFieldValidator ID="cnfrmpassword_required" runat="server" ControlToValidate="txtuser_cnfrmpassword"
                        CssClass="failureNotification" ErrorMessage="Confirm Password is Required">*</asp:RequiredFieldValidator>
                    </td>--%>
               </tr>
               <tr>
                    <td> <asp:Label ID="show_msg" runat="server" CssClass="failureNotification"></asp:Label></td>
               </tr>
<%--               <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="loginuser_validation" runat="server" CssClass="failureNotification"
                         ShowMessageBox="true"  Height="29px" />
                    </td>
               </tr>--%>
               <tr>
                    <td align="right"> 
                       <asp:Button runat="server" Text="Update" Height="33px" OnClick="pwdUpdate_Click" Width="78px" ID="pwdUpdate"/>
                    </td>
                    <td></td>
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
