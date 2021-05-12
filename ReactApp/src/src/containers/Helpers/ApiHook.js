import axios from "axios";

const UseApi =(apiPoint)=>(
axios.create({ 
     baseURL:"https://localhost:10001"+ apiPoint, 
     headers : {
          'Access-Control-Allow-Origin':'*',
          'Access-Control-Allow-Headers':'*',
          'Content-Type' : 'application/json;'
     }
})); 

export default UseApi;