import {Link} from "react-router-dom";
import "./SliderItem.css";
import "./Slider.css";
import {useState,useEffect, useMemo} from "react";
import picture from "../../images/1.jpg";
import useSliderHook from "../Helpers/SliderHook";

const SliderCircle = ({showItem,datakey})=>{
    return datakey===showItem?(<span className="span__item orange" ></span>):(<span className="span__item white" ></span>);
};

const SliderContainer = (props)=>{
    const sliderData = useSliderHook();
return <>
    <Slider sliderData={sliderData}/>
</>

};


const Slider = ({sliderData})=>{
    /*
    */
    const [currentItem,setCurrentItem] = useState({number:1,
        side:"right",
        previous:1
    });
    useEffect(() => {
        const sliderInterval = setInterval(()=>{
            rightArrowHandler();
        },3000);
        return () => {
            clearInterval(sliderInterval);
        }
    }, [currentItem.number]);
   
    const leftArrowHandler=()=>{
        if(currentItem.number-1< 1){
            setCurrentItem({number:sliderData.length,side:"animate__left",previous:1});
        }else{
            let copyCurrent = currentItem.number;
            setCurrentItem({number:copyCurrent-1,side:"animate__left",previous:copyCurrent});
        }
    }
    const rightArrowHandler=()=>{
        if(currentItem.number+1 > sliderData.length){
            setCurrentItem({number:1,side:"animate__right",previous:sliderData.length});
        }else{
            let copyCurrent = currentItem.number;
            setCurrentItem({number:copyCurrent+1,side:"animate__right",previous:copyCurrent});
        }
    }
    return (<div className="SliderContainer">
        <div className="img__Container">
            {sliderData.map((item,i)=>{return (<SliderItem item={item} datakey={i+1} key={i+1} previous={currentItem.previous} animateSide={currentItem.side} showItem={currentItem.number}/>)})}
        </div>
            {/* <div className="slider__arrows"> */}
                <span className="leftarrow" onClick={leftArrowHandler}></span>
                <span className="rightarrow" onClick={rightArrowHandler}></span>
            {/* </div> */}
                <span className="circle__item__container">
                {sliderData.map((e,i)=> {return (<SliderCircle key={"pic"+ i} showItem={currentItem.number} datakey={i+1} />);})}   
            </span>
        </div>)
};
export default SliderContainer;

const SliderItem=({item,datakey, showItem,animateSide,previous})=> {
    const currentClass = showItem===datakey?"figure__img " +animateSide:"figure__img__hidden";
    return (
        <figure className={currentClass} style={{zIndex:datakey===previous?-1:null}}>
            <img src={item.picture.default} height="100%" width="100%" alt={"slider "+ datakey} />
            <figcaption className="location__info">{item.description}</figcaption>
        </figure>);
}
