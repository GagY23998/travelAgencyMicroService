import {useState} from "react"

const UserFilter = ()=>{

    const [userFields, setuserFields] = useState(null)

    return <div className="userFields">
        <div className="user__field">
            <span>User Name:</span> <span><input type="text" /></span>
        </div>
        <div className="user__field">
            <span>User Surname:</span> <span><input type="text" /></span>
        </div>
        <div className="btn__searchUser"><button type="button">Search</button></div>
    </div>

}
export default UserFilter