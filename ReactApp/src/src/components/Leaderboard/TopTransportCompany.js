import {useState,useEffect} from "react";
import TCompany from "../TCompany/TCompany";
import UseApiHook from "../../containers/Helpers/ApiHook";
const TopHotel = ()=>{
    const [tcompanies,setTcompanies] = useState([]);
    useEffect(() => {
        const apiCall = UseApiHook("/toffer/topCompanies");
        apiCall.get().then(data => setTcompanies(data.data)).catch(err => console.log(err));        
    }, []);
    return <>
        {tcompanies.map((e,i)=> <TCompany key={e} data={e} />)}
    </>;
};

export default TopHotel;