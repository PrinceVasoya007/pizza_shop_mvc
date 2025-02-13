// sidebarr

const sidebar = document.getElementById("sidebar_menu");
const menu_icon = document.getElementById("menu_icon");

console.log("hellow");

let toggle_status = false;
console.log(toggle_status);

menu_icon.onclick =function(){

    toggle_status= !toggle_status;
  
    if (toggle_status){
       
      
      sidebar.classList.add("d-none");
     
    }
    else{
        sidebar.classList.remove("d-none");
    }
}

togglePassword.addEventListener('click', function () {
  // Toggle input type between 'password' and 'text'
  const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
  passwordInput.setAttribute('type', type);

  // Toggle the eye icon
  const icon = this.querySelector('i');
  icon.classList.toggle('bi-eye-slash-fill');
  icon.classList.toggle('bi-eye-fill');
});
