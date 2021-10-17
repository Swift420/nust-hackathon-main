// getting all required elements
const inputBox = document.querySelector(".inputField input");
const addBtn = document.querySelector(".inputField button");
const todoList = document.querySelector(".todoList");
const deleteAllBtn = document.querySelector(".footer button");

// onkeyup event
inputBox.onkeyup = ()=>{
  let userEnteredValue = inputBox.value; //getting user entered value
  if(userEnteredValue.trim() != 0){ //if the user value isn't only spaces
    addBtn.classList.add("active"); //active the add button
  }else{
    addBtn.classList.remove("active"); //unactive the add button
  }
}

showTasks2(); //calling showTask function

addBtn.onclick = ()=>{ //when user click on plus icon button
  let userEnteredValue = inputBox.value; //getting input field value
  let getLocalStorageData2 = localStorage.getItem("New Todo Admin"); //getting localstorage
  if(getLocalStorageData2 == null){ //if localstorage has no data
    listArrayAdmin = []; //create a blank array
  }else{
    listArrayAdmin = JSON.parse(getLocalStorageData2);  //transforming json string into a js object
  }
  listArrayAdmin.push(userEnteredValue); //pushing or adding new value in array
  localStorage.setItem("New Todo Admin", JSON.stringify(listArrayAdmin)); //transforming js object into a json string
  showTasks2(); //calling showTask function
  addBtn.classList.remove("active"); //unactive the add button once the task added
}

function showTasks2(){
  let getLocalStorageData2 = localStorage.getItem("New Todo Admin");
  if(getLocalStorageData2 == null){
    listArrayAdmin = [];
  }else{
    listArrayAdmin = JSON.parse(getLocalStorageData2); 
  }
  const pendingTasksNumb = document.querySelector(".pendingTasks");
  pendingTasksNumb.textContent = listArrayAdmin.length; //passing the array length in pendingtask
  if(listArrayAdmin.length > 0){ //if array length is greater than 0
    deleteAllBtn.classList.add("active"); //active the delete button
  }else{
    deleteAllBtn.classList.remove("active"); //unactive the delete button
  }
  let newLiTag = "";
  listArrayAdmin.forEach((element, index) => {
    newLiTag += `<li>${element}<span class="icon" onclick="deleteTask(${index})"><i class="fas fa-trash"></i></span></li>`;
  });
  todoList.innerHTML = newLiTag; //adding new li tag inside ul tag
  inputBox.value = ""; //once task added leave the input field blank
}

// delete task function
function deleteTask(index){
  let getLocalStorageData2 = localStorage.getItem("New Todo Admin");
  listArrayAdmin = JSON.parse(getLocalStorageData2);
  listArrayAdmin.splice(index, 1); //delete or remove the li
  localStorage.setItem("New Todo Admin", JSON.stringify(listArrayAdmin));
  showTasks2(); //call the showTasks2 function
}

// delete all tasks function
deleteAllBtn.onclick = ()=>{
  listArrayAdmin = []; //empty the array
  localStorage.setItem("New Todo Admin", JSON.stringify(listArrayAdmin)); //set the item in localstorage
  showTasks2(); //call the showTasks2 function
}