import "./CityDetails.css";
import {useState,useEffect} from "react";
import UseApi from "../../..//containers/Helpers/ApiHook";
import HOffers from "../../Offers/HOffers";
import TOffers from "../../Offers/TOffers";

const CityDetails = ({item})=>{
    const [hOffers,setHOffers] = useState();
    const [tOffers,setTOffers] = useState();
    useEffect(() => {
    console.log(item);        
        const fetchData = async()=>{

            const hData = await UseApi("/hoffer").post("GetOffers",{
                   cityId: item.id
            });
            const tData = await UseApi("/toffer").post("GetOffers",{
                    cityId: item.id
            });
            setHOffers(()=>hData.data);
            setTOffers(()=>tData.data);
        }
        fetchData();

        return () => {
            setHOffers([]);
            setTOffers([]);
        }
    }, [item]);

    return <div className="cityDetails_Wrapper">
         <article className="city__container">
            <div className="cityimg__container">
                <img src={"data:image/jpg;base64,"+item.image} alt={item.name} width="250px" height="300px"/>
                <span>{item.name}</span>
            </div>
            <div className="city__info">
                <pre className="city__description">
                    {item.description}
                </pre>
            </div> 
        </article>
        <section className="cityDetail__hOffers">
            {
                <HOffers items={hOffers}/>
            }
        </section>
        <section className="cityDetail__tOffers">
            {
                <TOffers items={tOffers}/>
            }
        </section>
    </div>

};
export default CityDetails;