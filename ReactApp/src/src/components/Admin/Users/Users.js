import {useState,useEffect} from "react"
import UseApi from "../../../containers/Helpers/ApiHook"
import User from "./User"
import UserFilter from "./UserFilter"

const Users = ()=>{
    const [usersData, setUsersData] = useState([])
    const [userFields,setUserFields] = useState(null)
    useEffect(() => {

        const fetchData = async ()=> {
            const userdata = await UseApi("/user").post("",userFields)
            setUsersData(userdata.data)
        }

        fetchData()
        
        return ()=>setUsersData([])

    }, [userFields])

    const setUserFieldsHandler = (e,fieldsData)=>{
        setUserFields(fieldsData)
    }

    return <div className="a__users__container">
        <UserFilter setFields={setUserFieldsHandler}/>
        {
            usersData.map((e,i)=><User key={"user"+ i} data={e}/>)
        }
    </div>
}

export default Users