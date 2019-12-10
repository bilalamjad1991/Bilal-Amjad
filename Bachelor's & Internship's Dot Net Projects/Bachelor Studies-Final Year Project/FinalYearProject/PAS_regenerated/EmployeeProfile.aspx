<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="PAS_regenerated.EmployeeProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Employee Profile</title>
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
         function HideLabel() {
             document.getElementById('<%= lblError.ClientID %>').style.display = "none";


         }
         setTimeout("HideLabel();", 2500);
    </script>

    <script type="text/javascript">
        function HideLabel1() {
            document.getElementById('<%= lblUpdate.ClientID %>').style.display = "none";


        }
        setTimeout("HideLabel1();", 2000);
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
                         <li><asp:LinkButton ID="lnkbtnRegister" runat="server" Visible="False" 
            onclick="lnkbtnRegister_Click">Register</asp:LinkButton></li>
            </ul>
           
            <ul style="padding-left:60%; padding-top:">
           
            <li style="font-size: 10px "><asp:LinkButton ID="lnkbtnChangePassword" runat="server" 
              onclick="lnkbtnChangePassword_Click1">Change Password</asp:LinkButton></li>
      <li style="font-size: 10px"> <asp:LinkButton ID="lnkbtnSignout" runat="server" 
              onclick="lnkbtnSignout_Click1">Signout</asp:LinkButton> </li>
						
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
						<h3>Employee Profile</h3>
						<p style="color:#F2F2F2">test</p>
                       
                       <div>
          <table>
                <tr>
                <td class="lable"> 
                        <asp:Label Height="25px" Width="208px" ID="lblEmpId" 
                            runat="server" Text="Employee ID:" Font-Size="Medium" Font-Bold="True" 
                            ForeColor="Black"></asp:Label> </td>                
                </tr>

                <tr>
                        <td>
                            <asp:TextBox ID="txtEmpId" runat="server" Height="32px" Width="208px" 
                                ReadOnly="False"></asp:TextBox>
                            </td>
                            <td>
                            <asp:Button runat="server" Text="Search"  ID="btnSearchEmployee" Height="32px" 
                                     Width="82px" onclick="btnSearchEmployee_Click" />
                            </td>
                </tr>
                <tr>
                        <td>
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" 
                                Font-Size="Small"></asp:Label>
                        </td>
                </tr>
               <%-- <tr>
                    <td class="lable"> 
                        <asp:Label Height="25px" Width="100px" ID="lblUserName" 
                            runat="server" Text="User Name:" Font-Size="Medium" Font-Bold="True" 
                            ForeColor="Black"></asp:Label> </td>
                </tr>--%>
               <%-- <tr> 
                   <td>  <asp:TextBox ID="txtUser" runat="server" ToolTip="Enter User Name" 
                           Height="32px" Width="208px" ReadOnly="True"></asp:TextBox></td>
                
                   <td>
                    <asp:RegularExpressionValidator ID="regexp_username" runat="server" ErrorMessage="Enter username between 4-25 characters."
                     ControlToValidate="txtuser" ValidationExpression="^[a-zA-Z0-9]{4,25}$" 
                           CssClass="failureNotification"></asp:RegularExpressionValidator>
                   </td>
                </tr> --%>

                <tr>
                        <td class="lable">
                             <asp:Label Height="25px" Width="100px" ID="Label1" 
                            runat="server" Text="First Name:" Font-Size="Medium" Font-Bold="True" 
                            ForeColor="Black"></asp:Label>
                        </td>
                </tr>
                <tr>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Enter First Name" 
                                Height="32px" Width="208px" ReadOnly="True"></asp:TextBox>
                        </td>

                        <td>
                        <%--regex here--%>

                          <asp:RegularExpressionValidator ID="regex_FName" runat="server" ControlToValidate="txtFirstName" 
                         ErrorMessage="Enter First Name between 3-25 characters" ValidationExpression="^[a-zA-Z\s]{3,25}$"></asp:RegularExpressionValidator>

                        </td>
                </tr>
                 <tr>
                        <td class="lable">
                             <asp:Label Height="25px" Width="100px" ID="Label2" 
                            runat="server" Text="Last Name:" Font-Size="Medium" Font-Bold="True" 
                            ForeColor="Black"></asp:Label>
                        </td>
                </tr>
                <tr>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server" ToolTip="Enter Last Name" 
                                Height="32px" Width="208px" ReadOnly="True"></asp:TextBox>
                        </td>

                        <td>
                          <%--regex here--%>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLastName" 
                          ErrorMessage="Enter Last Name between 3-25 characters" ValidationExpression="^[a-zA-Z\s]{3,25}$"></asp:RegularExpressionValidator>
                       
                        </td>
                </tr>
                <tr>
                    <td class="label"> 
                        <asp:Label ID="bl" runat="server" Text="Contact No:" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label> </td>
                </tr> 
                <tr>
                    <td> <asp:TextBox ID="txtPhone" runat="server" 
                            ToolTip="Please Enter Your Mobile Number" Height="32px" Width="208px" 
                            ReadOnly="True"></asp:TextBox> </td>
      <%--              <td>
                        <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtPhone" 
                        CssClass="failureNotification" ErrorMessage="Contact No is Required.">*</asp:RequiredFieldValidator>
                    </td>--%>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter phone number in this format : 344-4111815"
                     ControlToValidate="txtPhone" ValidationExpression="^\d{3}( |-)?\d{7}" 
                            CssClass="failureNotification"></asp:RegularExpressionValidator>   <%--ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$" --%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Enter your Email:" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label> 
                    </td>                   
                 </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" ToolTip="Enter you Email " 
                            Height="32px" Width="208px" ReadOnly="True"></asp:TextBox>
                    </td>
    <%--                <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                        CssClass="failureNotification" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>--%>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="format: name@domainname.com" ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            CssClass="failureNotification"></asp:RegularExpressionValidator>
                    </td>
                 </tr>
                <tr>
                    <td class="label"> 
                        <asp:Label ID="lblAddress" runat="server" Text="Address:" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
                </tr>
                <tr>
                    <td> <asp:TextBox ID="txtAddress" runat="server" 
                            ToolTip="Enter Your Residential Address " Height="32px" Width="208px" 
                            ReadOnly="True"></asp:TextBox></td>
                    <td>
                       <%-- <asp:RegularExpressionValidator ID="Regexp_txtAddress" runat="server" ErrorMessage="Enter valid Address."
                     ControlToValidate="txtAddress" ValidationExpression=""></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
               <%-- <tr>
                        <td class="label">
                            <asp:Label ID="Label8" runat="server" Text="Enter Date Of Birth"
                            Font-Bold="true" Font-Size="Medium" ForeColor="Black"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtDOB" runat="server" TextMode="SingleLine" 
                             ToolTip="DOB Fromat:MM/DD/YYYY" Height="32px" Width="208px" ReadOnly="True"></asp:TextBox>                       
                    </td>
                    <td>
                    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDOB" CssClass="failureNotification" MinimumValue="12/31/1990" MaximumValue="1/1/2100" Text="Date format :MM/DD/YYYY" Display="Dynamic" Type="Date" runat="server"
            ErrorMessage="RangeValidator"></asp:RangeValidator>
                    </td>
                </tr>--%>
              <%--  <tr>
                    <td>
                        <asp:Label ID="label9" runat="server" Text="Date of Joining"
                         Font-Bold="true" Font-Size="Medium" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <asp:TextBox ID="txtDOJ" runat="server" TextMode="SingleLine" 
                            ToolTip="Date of Joining" Height="32px" Width="208px" ReadOnly="True"></asp:TextBox>                       
                    </td>
                </tr>--%>
              <%--  <tr>
                    <td class="label"> 
                        <asp:Label ID="Label5" runat="server" Text="Password:" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
                </tr>  
                <tr>
                    <td> <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Height="32px" Width="208px"></asp:TextBox></td>
                    
                    <td>
                        <asp:RegularExpressionValidator ID="Regexp_txtPwd" runat="server" ErrorMessage="Password length must be greater than 4."
                     ControlToValidate="txtPwd" ValidationExpression="(\w*)(\s*)(.*){4,}$" 
                            CssClass="failureNotification"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label"> 
                        <asp:Label ID="Label6" runat="server" Text="Confirm Password:" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
                </tr>
                <tr>
                    <td> <asp:TextBox ID="txtCnfrmPwd" runat="server" TextMode="Password" Height="32px" Width="208px"></asp:TextBox> </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ErrorMessage="Confirm password must match!" ControlToValidate="txtCnfrmPwd" 
                            ControlToCompare="txtPwd" CssClass="failureNotification"></asp:CompareValidator>
                    </td>
                    
                </tr>--%>
                <tr>
                    <td> </td>
                </tr>
               <%-- <tr>
                    <td>    
                        <asp:DropDownList ID="select_user_registration" runat="server" Height="33px" Width="205px">
                        <asp:ListItem Text="---Select User---" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Administrator" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Pharmacist" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Cashier" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td> <asp:Label ID="rgstr_msglbl" runat="server" CssClass="failureNotification"></asp:Label></td>
                </tr>--%>
               
                     <tr>
                            <td>
                                <asp:Button ID="btnEdit" Text="Edit Profile" runat="server" Height="33" 
                                    Width="78" onclick="btnEdit_Click" Visible="False"  />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Height="33" 
                                    Width="78" onclick="btnUpdate_Click" Visible="False" />
                             <asp:Button ID="btnCancel" runat="server"  Height="33px" Text="Cancel" 
                                    Width="78px" onclick="btnCancel_Click"  />
                        </td>
                     </tr>
                     <tr>
                            <td>
                                <asp:Label ID="lblUpdate" runat="server" Visible="False" Font-Bold="True" 
                                    Font-Size="Small"></asp:Label>
                            </td>
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
