import { useEffect, useState } from "react"
import "./ReservationFilter.css"

const ReservationFilter = ({searchReservations})=>{
    
    const [fieldDate, setfieldDate] = useState({
        firstName:"",
        lastName:"",
        startDate:null,
        finishDate:null
    })
        return <div className="bfilter__container">
        <div className="user__booking__filter">
            <span className="user__booking__field"><label>First Name:</label><input name="firstName" className="booking__user__input"type="text" /></span>
            <span className="user__booking__field"><label>Last Name:</label> <input name="lastName" className="booking__user__input"type="text" /></span>
        </div>
        <div className="date__booking__filter">
            <span className="date__booking__field"><label>Start Date:</label><input  className="booking__date__input" name="startdate"type= "date"/></span>
            <span className="date__booking__field"><label>Finish Date:</label><input className="booking__date__input" name="finishdate"type="date"/></span>
        </div>
        <div className="btn__booking__filter"><button className="btn__booking" type="button">Search</button></div>
    </div>

}
export default ReservationFilter