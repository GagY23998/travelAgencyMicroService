import "./City.css";
import {useState,useEffect} from "react";
const City = ({item,showCity})=>{
    const [compName,setCompName]=useState("City");

    useEffect(() => {
        setCompName("CityDetails");
    }, [])

    return (
        <article className="city__wrapper">
            <div className="cityimg__container">
                <img src={"data:image/jpg;base64,"+item.image} alt={item.name} width="250px" height="300px"/>
                <span>{item.name}</span>
            </div>
            <div className="city__info">
                <pre className="city__description">
                    {item.description}
                </pre>
            </div> 
            <span>
                <button type="button" onClick={(e)=>showCity(e,compName,item)} >See Offers</button>
            </span>
        </article>
    );
}
export default City;