<?php
session_start();

/*In this code I am fetching $name,$price,$quantity from
a form in the index.php file and saving them in a session
*/
$name = $_POST['name'];
$price = $_POST['price'];
$quantity = $_POST['qty'];

$product = array($name,$price,$quantity);

$_SESSION[$name] = $product;

header('location:index.php')

?>