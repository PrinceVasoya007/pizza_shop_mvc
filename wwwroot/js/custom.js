// sidebarr

const sidebar = document.getElementById("sidebar_menu");
const menu_icon = document.getElementById("menu_icon");

console.log("hellow");

// let toggle_status = false;
// console.log(toggle_status);

// menu_icon.onclick =function(){

//     toggle_status= !toggle_status;
  
//     if (toggle_status){
       
      
//       sidebar.classList.add("d-none");
     
//     }
//     else{
//         sidebar.classList.remove("d-none");
//     }
// }
 
try {
    const togglePassword = document.getElementById('toggle-password');
    const passwordInput = document.getElementById('password-input');

    if (togglePassword && passwordInput) {
        togglePassword.addEventListener('click', function () {
            // Toggle input type between 'password' and 'text'
            const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
            passwordInput.setAttribute('type', type);

            // Toggle the eye icon
            const icon = this.querySelector('i');
            icon.classList.toggle('bi-eye-slash-fill');
            icon.classList.toggle('bi-eye-fill');
        });
    } else {
        console.log();
        // ("Toggle password elements not found");
    }
} catch (error) {
    console.error('An error occurred:', error);
}

<<<<<<< HEAD

// $(document).ready(function() {
//   // Toggle password visibility

//   // Form submission event
//   $('#loginForm').on('submit', function(event) {
//       // Reset previous error messages
//       $('#emailError').hide();
//       $('#passwordError').hide();

//       let isValid = true;

//       // Validate email
//       const email = $('#email').val().trim();
//       const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
//       if (!email.match(emailPattern)) {
//           isValid = false;
//           console.log(email);
//           $('#emailError').text('Please enter a valid email address').show();
//       }

//       // Validate password
//       const password = $('#password-input').val().trim();
//       if (password.length < 6) {
//           isValid = false;
//           $('#passwordError').text('Password must be at least 6 characters long').show();
//       }

//       if (!isValid) {
//           event.preventDefault(); // Prevent form submission if validation fails
//       }
//   });
// });

=======
togglePassword.addEventListener('click', function () {
  // Toggle input type between 'password' and 'text'
  const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
  passwordInput.setAttribute('type', type);

  // Toggle the eye icon
  const icon = this.querySelector('i');
  icon.classList.toggle('bi-eye-slash-fill');
  icon.classList.toggle('bi-eye-fill');
});
>>>>>>> 1013046a434f40a48f370893b115c7192c50d75d
