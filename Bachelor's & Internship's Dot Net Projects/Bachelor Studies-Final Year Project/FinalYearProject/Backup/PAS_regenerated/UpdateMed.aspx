<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMed.aspx.cs" Inherits="PAS_regenerated.UpdateMed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Update Medicine Stock</title>

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
   <script type="text/javascript" language="javascript">
       $(document).ready(function () {
           $('#<%=lblNoRecords.ClientID%>').css('display', 'none');

           $('#<%=btnSubmit.ClientID%>').click(function (e) {
               $('#<%=lblNoRecords.ClientID%>').css('display', 'none'); // Hide No records to display label.
               $("#<%=gdRows.ClientID%> tr:has(td)").hide(); // Hide all the rows.

               var iCounter = 0;
               var sSearchTerm = $('#<%=txtSearch.ClientID%>').val(); //Get the search box value

               if (sSearchTerm.length == 0) //if nothing is entered then show all the rows.
               {
                   $("#<%=gdRows.ClientID%> tr:has(td)").show();
                   return false;
               }
               //Iterate through all the td.
               $("#<%=gdRows.ClientID%> tr:has(td)").children().each(function () {
                   var cellText = $(this).text().toLowerCase();
                   if (cellText.indexOf(sSearchTerm.toLowerCase()) >= 0) //Check if data matches
                   {
                       $(this).parent().show();
                       iCounter++;
                       return true;
                   }
               });
               if (iCounter == 0) {
                   $('#<%=lblNoRecords.ClientID%>').css('display', '');
               }
               e.preventDefault();
           })
       })
    </script>
  



  <link href="Styles/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $('#<%=txtSearch.ClientID %>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MedicineService.asmx/GetMedicineNames",
                        data: "{'medicineName':'" + request.term + "'}",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        success: function (result) {
                            response(result.d);
                        },
                        error: function (result) {
                            alert('There is a problem processing your request');

                        }
                    });
                }
            });

        });
    </script>

	<link rel="shortcut icon" type="image/x-icon" href="css/images/favicon.ico" />
	<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
	<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="all" />
	
	<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
     <script type="text/javascript">
         var jq172 = $.noConflict(true);
        </script>
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
                         <li><asp:LinkButton ID="lnkbtnRegister" runat="server" Visible="False" 
            onclick="lnkbtnRegister_Click">Register</asp:LinkButton></li>
            </ul>
           
            <ul style="padding-left:60%; padding-top:">
           
            <li style="font-size: 10px "><asp:LinkButton ID="lnkbtnChangePassword" runat="server" 
              onclick="lnkbtnChangePassword_Click">Change Password</asp:LinkButton></li>
      <li style="font-size: 10px"> <asp:LinkButton ID="lnkbtnSignout" runat="server" 
              onclick="lnkbtnSignout_Click">Signout</asp:LinkButton> </li>
						
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
						<h3>Update Medicine Stock</h3>
						<p style="color:#F2F2F2">test</p>
                           <asp:Label ID="Label1" runat="server" Text="Search Medicine:" Font-Bold="True" 
            ForeColor="Black"></asp:Label>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Search" 
            Font-Bold="True" ForeColor="Black" Height="27px" Width="82px" />
        <br /> <br />
        <asp:GridView ID="gdRows" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataKeyNames="ProductName" DataSourceID="SqlDataSource1" PageSize="5" 
                            onrowupdating="gdRows_RowUpdating">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
                    ReadOnly="True" SortExpression="ProductName" />
                <asp:BoundField DataField="P_Salt" HeaderText="Salt" 
                    SortExpression="P_Salt" />
                <asp:BoundField DataField="P_Company" HeaderText="Company" 
                    SortExpression="P_Company" />
                <asp:BoundField DataField="P_Price" HeaderText="Unit Price" 
                    SortExpression="P_Price" />
                <asp:BoundField DataField="P_Qty" HeaderText="Stock Quantity" SortExpression="P_Qty" />
               
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PharmacyConnectionString %>" 
            DeleteCommand="DELETE FROM [Medicines] WHERE [ProductName] = @ProductName" 
            InsertCommand="INSERT INTO [Medicines] ([ProductName], [P_Salt], [P_Company], [P_Price], [P_Qty]) VALUES (@ProductName, @P_Salt, @P_Company, @P_Price, @P_Qty)" 
            SelectCommand="SELECT * FROM [Medicines]" 
            
                            UpdateCommand="UPDATE [Medicines] SET [P_Salt] = @P_Salt, [P_Company] = @P_Company, [P_Price] = @P_Price, [P_Qty] = @P_Qty WHERE [ProductName] = @ProductName" 
                            onupdated="SqlDataSource1_Updated">
            <DeleteParameters>
                <asp:Parameter Name="ProductName" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="P_Salt" Type="String" />
                <asp:Parameter Name="P_Company" Type="String" />
                <asp:Parameter Name="P_Price" Type="String" />
                <asp:Parameter Name="P_Qty" Type="String" />
               
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="P_Salt" Type="String" />
                <asp:Parameter Name="P_Company" Type="String" />
                <asp:Parameter Name="P_Price" Type="String" />
                <asp:Parameter Name="P_Qty" Type="String" />
               
                <asp:Parameter Name="ProductName" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <asp:Label ID="lblNoRecords" Text="No records to display" runat="server" ForeColor="red"></asp:Label>
       
						
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






 