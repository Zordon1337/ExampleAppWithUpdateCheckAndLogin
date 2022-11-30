<?php
$version = "0.0.1";
$v = $_GET['v'];

if($v == $version)
{
    echo "0";
}
if($v != $version)
{
    echo "1";
}
?>