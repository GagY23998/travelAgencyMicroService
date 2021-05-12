import { useState,useEffect } from "react"
import UseApi from "../../../containers/Helpers/ApiHook"
import Reservation from "./Booking/Reservation"
import ReservationFilter from "./Booking/ReservationFilter"

const Reservations = ()=>{
        
    const [bookings, setBookings] = useState([])
    const [searchData,setSearchData] = useState(null)

    useEffect(() => {
        const fetchData = async ()=>{
            try {
                if(searchData){
                    const fetchedData = await UseApi("/booking").post("/GetBookings",searchData)    
                    setBookings(fetchedData.data)                
                }
            } catch (error) {
                console.log(error.message);
            }
        }
        fetchData()
        return ()=>setBookings([])
    }, [searchData])

    const searchReservationsHandler = (e,searchData)=>{
        setSearchData(searchData)
    }

    return<>
        <ReservationFilter searchReservations={searchReservationsHandler}/>
       {
           bookings && bookings.length!==0 ? bookings.map((e,i)=>{
               return <Reservation key={"Reservation" + i} data={e} />
           }):null
       } 
    </>

}
export default Reservations;