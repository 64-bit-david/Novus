<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="WebAdo.NavBar" %>

<ul class="navbar navbar-dark bg-primary">
    <li class="nav-item">
        <a class="nav-link" href="Default.aspx">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Person.aspx">Person</a>
    </li>
</ul>


<style>
    .navbar{
        display: flex;
        justify-content: flex-start;
        list-style: none;
    }
    a{
        color: white;
    }
</style>