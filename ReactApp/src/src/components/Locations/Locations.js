import UseApi from "../../containers/Helpers/ApiHook";
import Location from "./Location/Location";
import City from "../City/City";
import {useEffect, useState} from "react";
import Modal from "../../containers/Modal/Modal";
import "./Locations.css";

const Locations =(props)=>{

    const [countryData, setCountryData] = useState();
    const [citiesData,setCityData] = useState();
    const [selectedCountry,setCountryId] =useState();
    const [modalComponent,setModalComponent] = useState({modalComponent:null,data:null});
    const countriesStyle = {
            display:"grid",
            gridTemplateColumns:"repeat(auto-fit,minmax(250px,1fr))"  
    };
    useEffect(() => {

        const fetchCities = async ()=>{
            const cities = await UseApi("/city").get("GetCountryCities",{
                params:{
                    countryId: selectedCountry
                }
            })
            console.log(cities);
            setCityData(cities.data);

        };
        if(selectedCountry){
            fetchCities();
        }

        return () => {
            setCityData(null);
        }
    }, [selectedCountry])
    useEffect(() => {
        
        const getData = async () =>{
            const countries = await UseApi("/country").get("GetCountries");
            setCountryData(countries.data);
        };
        getData();

    }, []);

    const setCitiesHandler = (element,countryId)=>{
        setCountryId(countryId);
    }
    const showCityHandler = (e,compName,data)=>{
        setModalComponent(()=>{return {modalComponent:compName,data:data};})
    }

    return (<div className="locations" style={countriesStyle}>
        {
            countryData && countryData.length!==0?
            countryData.map((el,i)=>{
                return <Location item={el} setCity={setCitiesHandler} key={"element" + i}/>
            }):<p>Loading....</p>
        }
        <section className="city__section">
        {

            citiesData && citiesData.length!==0?
            citiesData.map((e,i)=>{
                return <City item={e} key={"city"+ i} showCity={showCityHandler}/>
            }):null
        }
        </section>
        <Modal {...modalComponent}/>
    </div>)
};

export default Locations;