# Ajax Project

With this project i learned how to consume API with Ajax 

## Technologies Used
The following technologies have been used in this project:

- **Ajax**
- **.NET 6**
- **Bootstrap**
- **MVC**
- **JavaScript**

## Features
- Fetch customer list
- Add a new customer
- Delete a customer
- Update customer details
- Fetch a single customer by ID

## Requirements
- jQuery library
- SweetAlert library (for success messages)

## AJAX Operations

```javascript
$("#btn1").click(function (){
    $.ajax({
        contentType: "application/json",
        dataType:"json",
        type:"GET",
        url:"/Customer/CustomerList",
        success: function (funk1){
            let customers = jQuery.parseJSON(funk1);
            console.log(customers);

            let tableHtml = `<table class="table table-bordered">`
            + "<tr>"
            + "<th>Customer Id</th>"
            + "<th>Customer Name</th>"
            + "<th>Customer Surname</th>"
            + "</tr>";

            $.each(customers, (index, value) => {
                tableHtml += `<tr>`
                + `<td>${value.CustomerId}</td>`
                + `<td>${value.CustomerName}</td>`
                + `<td>${value.CustomerSurname}</td>`
                + `</tr>`;
            });
            tableHtml += "</table>";
            $("#customerList").html(tableHtml);
        }
    });
});

$("#btn2").click(function (){
    let values = {
        CustomerName: $("#txtCustomerName").val(),
        CustomerSurname: $("#txtCustomerSurname").val()
    };

    $.ajax({
        url: "/Customer/CreateCustomer/",
        data: values,
        success: function (funk2){
            let result = jQuery.parseJSON(funk2);
            swal("Customer added succesfully", "Customer Added!", "success");
        }
    });
});

$("#btn3").click(function(){
    let id = $("#txtDeleteId").val();
    $.ajax({
        url: "/Customer/DeleteCustomer/" + id,
        success: function(funk3){
        swal("Customer deleted succesfully", "Customer Deleted", "success");
        }
    });
});

$("#btn4").click(function(){
    let values = {
        CustomerId: $("#txtEditId").val(),
        CustomerName: $("#txtEditName").val(),
        CustomerSurname: $("#txtEditSurname").val()
    };

    $.ajax({
        url: "/Customer/UpdateCustomer/",
        data: values,
        success: function(funk4){
           swal("Customer updated succesfully", "Customer Updated!", "success")
        }
    });
});

$("#btn5").click(function() {
    let id = $("#txtGetId").val();
    $.ajax({
        contentType: "application/json",
        dataType: "json",
        url: "/Customer/GetCustomer/" + id,
        success: function(funk5){
            let result = jQuery.parseJSON(funk5);
            console.log(result);
        }
    });
});
```

## Screenshot

| Default |
|--------------|
| ![Default Page](AjaxProjectExample/AjaxProjectExample/wwwroot/GitHubImages/ajaxProjectHome.png) |