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

showTasks(); //calling showTask function

addBtn.onclick = ()=>{ //when user click on plus icon button
  let userEnteredValue = inputBox.value; //getting input field value
  let getLocalStorageData = localStorage.getItem("New Todo Research"); //getting localstorage
  if(getLocalStorageData == null){ //if localstorage has no data
    listArrayResearch = []; //create a blank array
  }else{
    listArrayResearch = JSON.parse(getLocalStorageData);  //transforming json string into a js object
  }
  listArrayResearch.push(userEnteredValue); //pushing or adding new value in array
  localStorage.setItem("New Todo Research", JSON.stringify(listArrayResearch)); //transforming js object into a json string
  showTasks(); //calling showTask function
  addBtn.classList.remove("active"); //unactive the add button once the task added
}

function showTasks(){
  let getLocalStorageData = localStorage.getItem("New Todo Research");
  if(getLocalStorageData == null){
    listArrayResearch = [];
  }else{
    listArrayResearch = JSON.parse(getLocalStorageData); 
  }
  const pendingTasksNumb = document.querySelector(".pendingTasks");
  pendingTasksNumb.textContent = listArrayResearch.length; //passing the array length in pendingtask
  if(listArrayResearch.length > 0){ //if array length is greater than 0
    deleteAllBtn.classList.add("active"); //active the delete button
  }else{
    deleteAllBtn.classList.remove("active"); //unactive the delete button
  }
  let newLiTag = "";
  listArrayResearch.forEach((element, index) => {
    newLiTag += `<li>${element}<span class="icon" onclick="deleteTask(${index})"><i class="fas fa-trash"></i></span></li>`;
  });
  todoList.innerHTML = newLiTag; //adding new li tag inside ul tag
  inputBox.value = ""; //once task added leave the input field blank
}

// delete task function
function deleteTask(index){
  let getLocalStorageData = localStorage.getItem("New Todo Research");
  listArrayResearch = JSON.parse(getLocalStorageData);
  listArrayResearch.splice(index, 1); //delete or remove the li
  localStorage.setItem("New Todo Research", JSON.stringify(listArrayResearch));
  showTasks(); //call the showTasks function
}

// delete all tasks function
deleteAllBtn.onclick = ()=>{
  listArrayResearch = []; //empty the array
  localStorage.setItem("New Todo Research", JSON.stringify(listArrayResearch)); //set the item in localstorage
  showTasks(); //call the showTasks function
}