import {useState,useEffect} from "react";
import UseApi from "../../containers/Helpers/ApiHook";
import "./Ratings.css";
import Rating from "./Rating/Rating";

const Ratings =(props)=>{

    const [ratingData, setRatingData] = useState([]);
    useEffect(()=>{
        const getHRating = async()=>
        {
             let hRatings = await  UseApi("/hotel").get("/topRatings");
            setRatingData(hRatings.data);
        }
        const getTRating = async()=>{
           let tRatings = await  UseApi("/tcompany").get("/topRatings");
            return tRatings;
        }
        // setRatingData(getHRating());
        // getTRating();
        getHRating();
        // setRatingData(getHRating().data);
        // return ()=> setRatingData([]);
    },[]);
  
    var ratings = (ratingData instanceof Array && ratingData.length!== 0)?
    ratingData.map((el,i)=>{
        return (<Rating item={el} key={"rating"+ i} subComponent="Hotel" />) ;
    })
    :<span>What's up</span>;
    
    return (
    <div className="ratingWrapper" >
        <section className="ratingContainer">
        {ratings}
    </section>
        </div>);
    }

export default Ratings;

