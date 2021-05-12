import HOffers from "../Offers/HOffers";
import TOffers from "../Offers/TOffers";
import {useState,useEffect} from "react";
import UseApi from "../../containers/Helpers/ApiHook";
import SliderContainer from "../../containers/Slider/Slider";
import Ratings from "../Ratings/Ratings";
const NewsFeed = ()=> {
const [toffers,setToffers] = useState([]);
const [hoffers,setHoffers] = useState([]);

useEffect(() => {
    const fetchHOfferData = async()=>{
        const hoffers = await UseApi("/hoffer").get("/GetLatestOffers");
        setHoffers(hoffers.data);
    };
    const fetchTOfferData = async()=>{
        const toffers = await UseApi("/toffer").get("/GetLatestOffers");
        setToffers(toffers.data);
    };
    fetchTOfferData();
    fetchHOfferData();
}, []);
useEffect(()=>{
    console.log(hoffers);
    console.log(toffers);
},[hoffers,toffers]);

if(toffers.length!==0 ||hoffers.length!==0){
    return(<>
        <SliderContainer/>
        <HOffers items={hoffers}/>
        <TOffers items={toffers}/>
        <Ratings/>
        </>);
}
return (<span>Loading...</span>);
};


export default NewsFeed;