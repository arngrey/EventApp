import styled from "styled-components";

export type DefaultPopupProps = {
    isVisible: boolean;
}

export const DefaultPopup = styled.div<DefaultPopupProps>`
    position: absolute;
    display: flex;
    flex-direction: column;
    width: inherit;
    height: inherit;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    max-width: 60rem;
    max-height: 50rem;
    visibility: ${props => props.isVisible ? "visible" : "hidden"}
`