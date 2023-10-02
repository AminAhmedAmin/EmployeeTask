
let baseUrl= "https://localhost:7159/api/Employee/";
var addresses = [];
var tablebody =  $(".employee-table tbody");
let page=1;

$(document).ready(function () {

  Index(page=1)

});

// view data && pagination  
function next() {
  page++
  Index(page)
  }


  function Prev() {
    page=page-1;
    if (page==0) {page=1 }
    else{
      Index(page)
    }

   
    }

function Index(page) {
  tablebody.empty();
fetch(    `${baseUrl}GetEmployees?page=${page}` )
  .then(response => {
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return response.json(); // Parse the JSON response
  })
  .then(data => {
   
    // Loop through the data using a forEach loop
    data.forEach(item => {

      var newRow = '<tr>' +
                    '<td>' + item.name  + '</td>' +
                    '<td>' + item.age + '</td>' +
                    '<td>';

                // Iterate through the inner list (addresses)
                $.each(item.addresses, function(addressIndex, addressItem) {
                    newRow += addressItem.description + '<br>';
                });

                newRow += '</ul></td>' +
                '<td>' +
                '<button class="updateBtn" data-id="' + item.id + '">Update</button>' +
                '<button class="deleteBtn" data-id="' + item.id + '">Delete</button>' +
                '</td>' +
                '</tr>';
      tablebody.append(newRow);
     
    });

    


  })
  .catch(error => {
    console.error('There was a problem with the fetch operation:', error);
  });

}




//AddData
  // Add button click event
  $("#addButton").click(function () {
     
    $(".popup").show();

    
 });

 $("#addAddress").click(function () {
  var inputCount = $(".addressInput").length + 1;
  var newInput = '<input type="text" class="addressInput" placeholder="Address ' + inputCount + '">';
                $("#addressContainer").append(newInput);


});




// Save or and send data
$(".btn-submit").click(function () {


  if(Validtion()==0)
  {
         

  // Get the form values
  var name = $("#name").val();
  var age = $("#age").val();
  
  addresses = []; 

  // Collect values from address input fields
  $(".addressInput").each(function () {
      var addressValue = $(this).val().trim();
      if (addressValue !== "") {
          addresses.push(addressValue);
      }
  });
  // Create a data object with the form values
  var data = {
      name: name,
      age: age,
      addresses: addresses
  };



  var employeeDTO = JSON.stringify(data);
 //  Send the data to the server using AJAX
  $.ajax({
      url:baseUrl+"AddEmployee", 
      method: 'POST', 
      data: 'json',
      contentType: 'application/json; charset=utf-8', // Set the content type to JSON
      data: employeeDTO, // Convert data to JSON string
      success: function(data, status, xhr) {

       if (xhr.status === 200) {

         Swal.fire(
           ' تم الاضافة ',
           '',
           'success'
         )
         setTimeout(function () {
           window.location.reload();
         }, 2000);
       
         $(".popup").hide();
       } else {
         
       }
      
      
      
      },
      error: function(error) {
         
      }
  });

  }
 
 });

 function AppendNewRow(Data) {
  
  
}



 
 $(".btn-Close").click(function () {
     
  $(".popup").hide();

  
});





//  ********************************************************** update **********************************//

// Update and Delete button click events (add them dynamically to each row)

$(document).on('click touch', '.updateBtn', function () { 
  $(".Updateformpopub").show();
var id = $(this).data('id'); 
fetchData(id)
});

// Function to fetch data using AJAX
function fetchData(id) {

  $.ajax({
    url:`${baseUrl}GetEmployee?id=${id}`, 
    type: 'GET',
    dataType: 'json',
    success: function (data) {
      console.table (data)
      populateForm(data);
    },
    error: function (xhr, status, error) {
      console.error('Error fetching data:', error);
    }
  });
}





// Function to populate form inputs
function populateForm(data) {
  $('#UpdateId').val(data.id);
  $('#Updatename').val(data.name);
  $('#Updateage').val(data.age);
  console.table (data)
  // Clear any existing addresses
  $('#UpdateaddressContainer').empty();

  // Append addresses to the container
  data.addresses.forEach(function (address, index) {
    $('#UpdateaddressContainer').append(
      `<label for="Updateaddress${index}">Address ${index + 1}:</label>
       <input type="text"  class="UpdateaddressInput" id="Updateaddress${index}" name="address${index}" value="${address.description  }"><br>`
    );
  });
}



$(".Updatebtn-submit").click(function () {

   // Get the form values
   var id = $("#UpdateId").val();
   var name = $("#Updatename").val();
   var age = $("#Updateage").val();
   
   addresses = []; 

   // Collect values from address input fields
   $(".UpdateaddressInput").each(function () {
       var addressValue = $(this).val().trim();
       if (addressValue !== "") {
           addresses.push(addressValue);
       }
   });
   // Create a data object with the form values
   var data = {
       id:id,
       name: name,
       age: age,
       addresses: addresses
   };

console.table(data);

   var employeeDTO = JSON.stringify(data);
  //  Send the data to the server using AJAX
   $.ajax({
       url:baseUrl+"UpdateEmployee", 
       method: 'POST', 
       data: 'json',
       contentType: 'application/json; ', // Set the content type to JSON
       data: employeeDTO, // Convert data to JSON string
       success: function(data, status, xhr) {

        if (xhr.status === 200) {

          Swal.fire(
            ' تم التعديل ',
            '',
            'success'
          )
          setTimeout(function () {
            window.location.reload();
          }, 2000);
        
          $(".popup").hide();
        } else {
          
        }
       
       
       
       },
       error: function(error) {
          
       }
   });
 });



$(".Updatebtn-Close").click(function () {
     
  $(".Updateformpopub").hide();

});



//  ********************************************************** delete **********************************//


$(document).on('click touch', '.deleteBtn', function () {
  var id = $(this).data('id');
  $(this).parent().parent().remove();
  $.ajax({
    url:`${baseUrl}deleteEmployee?id=${id}`, 
    type: 'Delete',
    data: 'json',
    success: function (data) {
     
    },
    error: function (xhr, status, error) {
      console.error('Error fetching data:', error);
    }
  });
});


function Validtion() {
  var name = $("#name").val();
   var age = $("#age").val();
   var adress = $("#adress").val();
   var chek=0;


   if (name === '' ) {
    
    $("#valitionname").text("name are required")
    chek++
  }

  if ( age === '' ) {
  
    $("#valitionage").text("age are required")
    chek++
  }
  if ( adress === '') {
   
    $("#valitionadress").text("adress are required")
    chek++
  }

  
  if (name.includes(' ')) {

    $("#valitionname").text("Name cannot contain spaces.")
    chek++
  }
  if (age < 21) {
   
    $("#valitionage").text("Age must be at least 21")
    chek++
  }

   return chek++

}










