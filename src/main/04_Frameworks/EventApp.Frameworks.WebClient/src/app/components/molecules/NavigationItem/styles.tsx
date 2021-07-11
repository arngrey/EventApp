import styled from "styled-components";

export const DefaultNavigationItem = styled.div`
    display: flex;
    height: 100%;
    width: 100%;
    position: relative;
    background-color: lightgrey;
    align-items: center;
    justify-content: center;
    &>a {
        width: 100%;
        height: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
    }
`