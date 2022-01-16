import styled from "styled-components";

export type CommonTableRowContainerProps = {
    height: string;
}

export const CommonTableRowContainer = styled.div<CommonTableRowContainerProps>`
    height: ${props => props.height}
    width: 100%;
    display: flex;
    position: relative;
    flex-direction: row;
    &:hover {
        background-color: grey;
        cursor: pointer;
    }
`