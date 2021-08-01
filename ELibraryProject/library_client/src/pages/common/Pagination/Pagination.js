import { Pagination } from 'react-bootstrap';

const Paging = ({ list, setIndex }) => {
  let active = list.pageIndex;
  let items = [];
  for (let number = 1; number <= list.pageCount; number++) {
    items.push(
      <Pagination.Item key={number} active={number === active} onClick={() => setIndex(number)} activeLabel='' >
        {number}
      </Pagination.Item>,
    );
  }
  return (
    <Pagination>{items}</Pagination>
  );

}

export default Paging;