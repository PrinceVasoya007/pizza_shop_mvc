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

document.addEventListener('DOMContentLoaded', function () {
  const passwordInput = document.querySelector('input[name="password"]');
  const togglePassword = document.getElementById('password');

  togglePassword.addEventListener('click', function () {
      const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
      passwordInput.setAttribute('type', type);
      this.querySelector('i').classList.toggle('bi-eye-slash-fill');
      this.querySelector('i').classList.toggle('bi-eye-fill');
  });
});