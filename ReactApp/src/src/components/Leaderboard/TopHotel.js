import {useState,useEffect} from "react";
import Hotel from "../Hotel/Hotel";
import UseApiHook from "../../containers/Helpers/ApiHook";
const TopHotel = ()=>{
    const [hotels,setHotels] = useState([]);
    useEffect(() => {
        const apiCall = UseApiHook("/hoffer/topHotels");
        apiCall.get().then(data => setHotels(data.data)).catch(err => console.log(err));        
    }, []);
    return <>
        {hotels.map((e,i)=> <Hotel key={e} data={e} />)}
    </>;
};

export default TopHotel;